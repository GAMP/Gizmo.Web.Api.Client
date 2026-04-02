using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/verificationcomplete")]
    public sealed class VerificationCompleteWebApiClient : WebApiClientBase
    {
        public VerificationCompleteWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<VerificationCompleteResultCode> VerificationCompleteAsync(VerificationCompleteModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["verification"]);
            return PostAsync<VerificationCompleteResultCode>(parameters, model, cancellationToken);
        }

        public Task<PasswordRecoveryCompleteResultCode> RecoveryCompleteAsync(PasswordRecoveryCompleteModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["recovery"]);
            return PostAsync<PasswordRecoveryCompleteResultCode>(parameters, model, cancellationToken);
        }
    }
}
