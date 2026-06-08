using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    [UnsecureWebApiClient()]
    [WebApiRoute("api/user/v3/system")]
    public sealed class SystemWebApiClient : WebApiClientBase
    {
        public SystemWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<string> Version(CancellationToken ct = default)
        {
            var parameters = new UriParameters(["version"]);
            return GetAsync<string>(parameters, ct);
        }
    }
}
