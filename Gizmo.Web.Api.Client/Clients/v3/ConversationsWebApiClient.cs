using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Conversations web api client.
    /// </summary>
    /// <remarks>
    /// Experimental, operators only. Every call is answered for the calling operator: only conversations they take
    /// part in exist for them.
    /// </remarks>
    [WebApiRoute("api/v3/conversations")]
    public sealed class ConversationsWebApiClient : WebApiClientBase
    {
        public ConversationsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        private const string LAST_EVENT_ID_HEADER = "Last-Event-ID";

        private static readonly JsonSerializerOptions STREAM_JSON_OPTIONS = new(JsonSerializerDefaults.Web);

        /// <summary>
        /// Gets the caller's conversations, latest activity first.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task<IEnumerable<ConversationModel>> GetAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<IEnumerable<ConversationModel>>(UriParameters.Empty, cancellationToken);
        }

        /// <summary>
        /// Gets one of the caller's conversations.
        /// </summary>
        /// <param name="id">Conversation id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task<ConversationModel> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return GetAsync<ConversationModel>(new UriParameters([id]), cancellationToken);
        }

        /// <summary>
        /// Creates a conversation owned by the caller.
        /// </summary>
        /// <param name="model">The conversation; mentioned AIs and people are added, the first AI is the primary one.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task<ConversationModel> CreateAsync(ConversationCreateModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<ConversationModel>(UriParameters.Empty, model, cancellationToken);
        }

        /// <summary>
        /// Gets a page of a conversation's history, oldest first.
        /// </summary>
        /// <param name="id">Conversation id.</param>
        /// <param name="after">Only entries after this id; null to start at the beginning.</param>
        /// <param name="limit">Page size; the server uses 100 by default and at most 500.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <remarks>
        /// The history pages forward: pass the last entry's id as <paramref name="after"/> to get the next page.
        /// </remarks>
        public Task<IEnumerable<ConversationEntryModel>> GetEntriesAsync(Guid id, Guid? after = null, int? limit = null, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, string>();

            if (after.HasValue)
                query["after"] = after.Value.ToString();

            if (limit.HasValue)
                query["limit"] = limit.Value.ToString(CultureInfo.InvariantCulture);

            return GetAsync<IEnumerable<ConversationEntryModel>>(new UriParameters([id, "messages"], query), cancellationToken);
        }

        /// <summary>
        /// Sends a message.
        /// </summary>
        /// <param name="id">Conversation id.</param>
        /// <param name="model">The message; sending the same client message id again returns the original id and time.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task<ConversationMessageCreateResultModel> SendMessageAsync(Guid id, ConversationMessageCreateModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<ConversationMessageCreateResultModel>(new UriParameters([id, "messages"]), model, cancellationToken);
        }

        /// <summary>
        /// Adds a participant; staff only.
        /// </summary>
        /// <param name="id">Conversation id.</param>
        /// <param name="reference">The participant.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public async Task AddParticipantAsync(Guid id, ConversationReferenceModel reference, CancellationToken cancellationToken = default)
        {
            var model = new ConversationParticipantModel() { Reference = reference };
            await PostAsync<object?>(new UriParameters([id, "participants"]), model, cancellationToken);
        }

        /// <summary>
        /// Removes a participant; staff only.
        /// </summary>
        /// <param name="id">Conversation id.</param>
        /// <param name="reference">The participant.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public async Task RemoveParticipantAsync(Guid id, ConversationReferenceModel reference, CancellationToken cancellationToken = default)
        {
            var model = new ConversationParticipantModel() { Reference = reference };
            await DeleteAsync<object?>(new UriParameters([id, "participants"]), model, cancellationToken);
        }

        /// <summary>
        /// Closes a conversation.
        /// </summary>
        /// <param name="id">Conversation id.</param>
        /// <param name="reason">Why, if given.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public async Task CloseAsync(Guid id, string? reason = null, CancellationToken cancellationToken = default)
        {
            var model = new ConversationStatusChangeModel() { Reason = reason };
            await PostAsync<object?>(new UriParameters([id, "close"]), model, cancellationToken);
        }

        /// <summary>
        /// Reopens a conversation.
        /// </summary>
        /// <param name="id">Conversation id.</param>
        /// <param name="reason">Why, if given.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public async Task ReopenAsync(Guid id, string? reason = null, CancellationToken cancellationToken = default)
        {
            var model = new ConversationStatusChangeModel() { Reason = reason };
            await PostAsync<object?>(new UriParameters([id, "reopen"]), model, cancellationToken);
        }

        /// <summary>
        /// Streams the entries of all the caller's conversations as they are stored.
        /// </summary>
        /// <param name="lastEventId">The id of the last entry received before a reconnect; the server first re-sends
        /// what was stored from shortly before it, so entries already held must be dropped by id.</param>
        /// <param name="cancellationToken">Cancellation token; cancel to close the stream.</param>
        /// <remarks>
        /// One stream carries every conversation. The enumeration ends when the server closes the stream, for example
        /// when the client fell too far behind; reconnecting is the caller's choice, passing the last entry's id.
        /// Read here rather than with the shared SSE helper, which ignores event types and sends no last event id.
        /// </remarks>
        public async IAsyncEnumerable<ConversationEntryModel> StreamAsync(Guid? lastEventId = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var uri = CreateRequestUri(new UriParameters(["stream"]));

            using var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/event-stream"));

            if (lastEventId.HasValue)
                request.Headers.Add(LAST_EVENT_ID_HEADER, lastEventId.Value.ToString());

            using var response = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            await ThrowApiExceptionIfRequiredAsync(response, cancellationToken);

            using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);

            //keep-alive comments are skipped by the parser; event types this client does not know are skipped here
            await foreach (var item in SseParser.Create(stream, ParseItem).EnumerateAsync(cancellationToken))
            {
                if (item.Data != null)
                    yield return item.Data;
            }
        }

        private static ConversationEntryModel? ParseItem(string eventType, ReadOnlySpan<byte> data)
        {
            return eventType is "message" or "conversationEvent"
                ? JsonSerializer.Deserialize<ConversationEntryModel>(data, STREAM_JSON_OPTIONS)
                : null;
        }
    }
}
