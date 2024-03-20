using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Remote control web api client.
    /// </summary>
    [WebApiRoute("api/v2/remotecontrol")]
    public sealed class RemoteControlWebApiClient : WebApiClientBase
    {
        public RemoteControlWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<RemoteControlSessionModel> CreateSessionAsync(int hostId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(["hosts", hostId]);
            return GetAsync<RemoteControlSessionModel>(parameters, ct);
        }
    }
}
