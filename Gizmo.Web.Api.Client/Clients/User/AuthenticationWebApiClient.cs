using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    [WebApiRoute("api/user/v2/auth")]
    public sealed class AuthenticationWebApiClient : WebApiClientBase
    {
        public AuthenticationWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<AuthTokenResultModel> AccessTokenGetAsync(UserAccessTokenRequestModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "accesstoken" }, model);
            return GetAsync<AuthTokenResultModel>(parameters, cancellationToken);
        }

        public Task<AuthTokenResultModel> AccessTokenRefreshAsync(UserAccessTokenRefreshRequestModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "accesstoken", "refresh" }, model);
            return GetAsync<AuthTokenResultModel>(parameters, cancellationToken);
        }
    }
}
