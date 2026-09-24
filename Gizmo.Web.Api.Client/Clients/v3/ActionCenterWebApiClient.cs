using System;
using System.Net.Http;
using Gizmo.Web.Api.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Action center web api client.
    /// </summary>
    /// <remarks>
    /// Three calls, mirroring the server: one sync that returns everything the calling operator should
    /// be showing, and two view changes. Which entries come back is decided by the server from the
    /// caller's token, so there is nothing to pass and nothing a manager could ask for that is not its own.
    /// </remarks>
    [WebApiRoute("api/v3/actioncenter")]
    public sealed class ActionCenterWebApiClient : WebApiClientBase
    {
        public ActionCenterWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        /// <summary>
        /// Gets the open entries for the calling operator, with the ids of the ones they have read and hidden,
        /// as one consistent snapshot.
        /// </summary>
        /// <remarks>
        /// Called on connect and on every hub reconnect. The snapshot's sequence is the high-water mark:
        /// a created message at or below it is already in the snapshot and is ignored.
        /// </remarks>
        public Task<ActionCenterSyncModel> SyncAsync(CancellationToken cancellationToken = default)
        {
            return GetAsync<ActionCenterSyncModel>(UriParameters.Empty, cancellationToken);
        }

        /// <summary>
        /// Records that the calling operator has seen an entry.
        /// </summary>
        /// <param name="id">Entry id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task<UpdateResult> ReadAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "read"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        /// <summary>
        /// Records that the calling operator has hidden an entry.
        /// </summary>
        /// <param name="id">Entry id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task<UpdateResult> DismissAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "dismiss"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        /// <summary>
        /// Puts an entry the calling operator had hidden back on their list.
        /// </summary>
        /// <param name="id">Entry id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task<UpdateResult> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "restore"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }
    }
}
