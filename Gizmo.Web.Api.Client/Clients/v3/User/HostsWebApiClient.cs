using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    /// <summary>
    /// Hosts api client, user surface — actions of the authenticated user on a host.
    /// </summary>
    [WebApiRoute("api/user/v3/hosts")]
    public sealed class HostsWebApiClient : WebApiClientBase
    {
        public HostsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        /// <summary>
        /// Logs the authenticated user in on a host (the host QR code of the PC client login screen).
        /// </summary>
        public Task<UserHostLoginResultModel> LoginAsync(UserHostLoginModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["login"]);
            return PostAsync<UserHostLoginResultModel>(parameters, model, cancellationToken);
        }
    }
}
