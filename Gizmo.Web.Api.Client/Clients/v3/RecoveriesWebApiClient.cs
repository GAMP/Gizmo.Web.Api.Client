using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/recoveries")]
    public sealed class RecoveriesWebApiClient : WebApiClientBase
    {
        public RecoveriesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PasswordRecoveryStartResultModelByMobile> PasswordByPhoneAsync(string username, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["password", username, "phone"]);
            return PostAsync<PasswordRecoveryStartResultModelByMobile>(parameters, cancellationToken);
        }

        public Task<PasswordRecoveryStartResultModelByEmail> PasswordByEmailAsync(string username, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["password", username, "email"]);
            return PostAsync<PasswordRecoveryStartResultModelByEmail>(parameters, cancellationToken);
        }

        public Task<PasswordRecoveryCompleteResultCode> PasswordRecoveryCompleteAsync(string token, string confirmationCode, string newPassword, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["password", token, confirmationCode, "complete"], new RecoveryPasswordChangeModel { NewPassword = newPassword});
            return PostAsync<PasswordRecoveryCompleteResultCode>(parameters, cancellationToken);
        }
    }
}
