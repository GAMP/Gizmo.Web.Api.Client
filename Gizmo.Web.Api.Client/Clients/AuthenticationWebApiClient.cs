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

        public Task<AuthTokenResultModel> GetAsync(TokenParameters user, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "token" }, user);
            return GetAsync<AuthTokenResultModel>(parameters, ct);
        }

        public Task<AuthTokenResultModel> GetAsync(RefreshTokenParameters token, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "refreshtoken" }, token);
            return GetAsync<AuthTokenResultModel>(parameters, ct);
        }
    }
}
