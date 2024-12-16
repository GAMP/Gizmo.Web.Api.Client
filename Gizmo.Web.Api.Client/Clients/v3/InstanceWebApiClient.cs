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

        public Task<AuthenticationResultModel> AuthenticationAsync(AuthenticationParametersModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["authentication"]);
            return PostAsync<AuthenticationResultModel>(parameters, model, cancellationToken);
        }

        public Task<AuthorizationModel> AuthorizationStateAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["authorization"]);
            return GetAsync<AuthorizationModel>(parameters, cancellationToken);
        }

        public Task<AuthorizeResultModel> AuthorizationAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["authorization"]);
            return PostAsync<AuthorizeResultModel>(parameters, cancellationToken);
        }

        public Task<InstanceIdModel> InstanceIdAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["id"]);
            return GetAsync<InstanceIdModel>(parameters, cancellationToken);
        }
    }
}
