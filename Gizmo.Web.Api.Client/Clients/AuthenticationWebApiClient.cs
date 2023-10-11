using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("auth")]
    public sealed class AuthenticationWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public AuthenticationWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
            UseResponseWrapping = false;
        }
        #endregion

        public Task<AuthTokenResultModel> TokenGetAsync(TokenParameters user, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "token" }, user);
            return GetAsync<AuthTokenResultModel>(parameters, ct);
        }

        public Task<AuthTokenResultModel> TokenRefreshAsync(RefreshTokenParameters token, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "refreshtoken" }, token);
            return GetAsync<AuthTokenResultModel>(parameters, ct);
        }

        public Task<AuthTokenResultModel> AccessToken(AccessTokenRequestModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "accesstoken" }, model);
            return GetAsync<AuthTokenResultModel>(parameters, cancellationToken);
        }

        public Task<AuthTokenResultModel> AccessToken(UserAccessTokenRequestModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "user", "accesstoken" }, model);
            return GetAsync<AuthTokenResultModel>(parameters, cancellationToken);
        }

        public Task<AuthTokenResultModel> AccessTokenRefresh(AccessTokenRefreshRequestModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "accesstoken", "refresh" }, model);
            return GetAsync<AuthTokenResultModel>(parameters, cancellationToken);
        }

        public Task<AuthTokenResultModel> AccessTokenRefresh(UserAccessTokenRefreshRequestModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "user", "accesstoken", "refresh" }, model);
            return GetAsync<AuthTokenResultModel>(parameters, cancellationToken);
        }
    }
}
