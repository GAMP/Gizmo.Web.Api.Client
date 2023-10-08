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

        public Task<AccessTokenResultModel> TokenGetAsync(TokenParameters user, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "token" }, user);
            return GetAsync<AccessTokenResultModel>(parameters, ct);
        }

        public Task<AccessTokenResultModel> TokenRefreshAsync(RefreshTokenParameters token, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "refreshtoken" }, token);
            return GetAsync<AccessTokenResultModel>(parameters, ct);
        }

        public Task<AccessTokenResultModel> AccessToken(AccessTokenRequestModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "accesstoken" }, model);
            return GetAsync<AccessTokenResultModel>(parameters, cancellationToken);
        }
       
        public Task<AccessTokenResultModel> AccessToken(UserAccessTokenRequestModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "user", "accesstoken" }, model);
            return GetAsync<AccessTokenResultModel>(parameters, cancellationToken);
        }

        public Task<AccessTokenResultModel> AccessTokenRefresh(AccessTokenRefreshRequestModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "accesstoken", "refresh" }, model);
            return GetAsync<AccessTokenResultModel>(parameters, cancellationToken);
        }

        public Task<AccessTokenResultModel> AccessTokenRefresh(UserAccessTokenRefreshRequestModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "user", "accesstoken", "refresh" }, model);
            return GetAsync<AccessTokenResultModel>(parameters, cancellationToken);
        }
    }
}
