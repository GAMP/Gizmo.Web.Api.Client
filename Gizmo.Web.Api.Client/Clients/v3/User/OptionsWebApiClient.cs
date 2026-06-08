using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Server.Options;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    [UnsecureWebApiClient()]
    [WebApiRoute("api/user/v3/options")]
    public sealed class OptionsWebApiClient : WebApiClientBase
    {
        public OptionsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<RegionalOptions> RegionalAsync(CancellationToken ct = default)
        {
            var parameters = new UriParameters(["regional"]);
            return GetAsync<RegionalOptions>(parameters, ct);
        }
    }
}
