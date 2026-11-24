using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Web api client for the Gizmo.AI module chat endpoints.
    /// </summary>
    /// <remarks>
    /// The module endpoints speak json and answer with an unwrapped payload, so this client selects
    /// the json serializer and does not expect a wrapped response. The json serializer has to be
    /// registered by the host, otherwise the client falls back to the default serializer.
    /// </remarks>
    [WebApiRoute("modules/Gizmo.AI/api/ai/v0")]
    public sealed class AiChatWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="httpClient">Http client instance.</param>
        /// <param name="options">Web api client options.</param>
        /// <param name="payloadSerializerProvider">Payload serializer.</param>
        public AiChatWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
            //the module endpoints read a json request body and answer with an unwrapped json payload
            PayloadSerializerName = "json";
            UseResponseWrapping = false;
        }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Lists the connections the authenticated operator can select.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Available connections with their models.</returns>
        public Task<AiConnectionsResultModel> GetConnectionsAsync(CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "connections" });
            return GetAsync<AiConnectionsResultModel>(parameters, ct);
        }

        /// <summary>
        /// Creates a session for the authenticated operator.
        /// </summary>
        /// <param name="model">Session creation model.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Created session.</returns>
        public Task<AiSessionResultModel> CreateSessionAsync(AiSessionCreateModel model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "sessions" });
            return PostAsync<AiSessionResultModel>(parameters, model, ct);
        }

        /// <summary>
        /// Sends one message to an existing session.
        /// </summary>
        /// <param name="sessionId">Opaque session identifier.</param>
        /// <param name="model">Message model.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Message result with the tool calls of the turn.</returns>
        public Task<AiMessageResultModel> SendMessageAsync(string sessionId, AiMessageCreateModel model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "sessions", sessionId, "messages" });
            return PostAsync<AiMessageResultModel>(parameters, model, ct);
        }

        /// <summary>
        /// Ends a session of the authenticated operator.
        /// </summary>
        /// <param name="sessionId">Opaque session identifier.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <remarks>
        /// The endpoint answers with no content, so there is no result to read. A session the server
        /// does not know any more is refused with the shared error envelope.
        /// </remarks>
        public async Task DeleteSessionAsync(string sessionId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "sessions", sessionId });
            await DeleteAsync<bool>(parameters, ct).ConfigureAwait(false);
        }

        #endregion
    }
}
