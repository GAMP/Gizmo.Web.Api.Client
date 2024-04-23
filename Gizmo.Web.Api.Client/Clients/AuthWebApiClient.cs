using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [UnsecureWebApiClient()]
    [WebApiRoute("api/v2/auth")]
    public sealed class AuthWebApiClient : WebApiClientBase
    {
        public AuthWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<AuthTokenResultModel> AccessTokenGetAsync(AccessTokenRequestModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "accesstoken" }, model);
            return GetAsync<AuthTokenResultModel>(parameters, cancellationToken);
        }

        public Task<AuthTokenResultModel> AccessTokenRefreshAsync(AccessTokenRefreshRequestModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "accesstoken", "refresh" }, model);
            return GetAsync<AuthTokenResultModel>(parameters, cancellationToken);
        }
    }
}
