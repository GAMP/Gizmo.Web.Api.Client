using System.Net.Http;
using Gizmo.Web.Api.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/instance")]
    public sealed class InstanceWebApiClient : WebApiClientBase
    {
        public InstanceWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<AuthenticationStateModel> AuthenticationStateAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["authentication"]);
            return GetAsync<AuthenticationStateModel>(parameters, cancellationToken);
        }

        public Task<AuthenticationResultModel> AuthenticationAsync(AuthenticationParameters model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["authentication"]);
            return PostAsync<AuthenticationResultModel>(parameters, model, cancellationToken);
        }
    }
}
