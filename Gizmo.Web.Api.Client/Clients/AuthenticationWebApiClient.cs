using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("auth")]
    public class AuthenticationWebApiClient : WebApiClientBase
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
    }
}
