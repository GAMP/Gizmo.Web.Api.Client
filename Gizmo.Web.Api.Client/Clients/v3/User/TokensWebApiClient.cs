using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    [UnsecureWebApiClient()]
    [WebApiRoute("api/user/v3/tokens")]
    public sealed class TokensWebApiClient : WebApiClientBase
    {
        public TokensWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<VerificationCompleteResultCode> ConfirmAsync(TokenConfirmModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["confirm"]);
            return PostAsync<VerificationCompleteResultCode>(parameters, model, cancellationToken);
        }
    }
}
