using Gizmo.Web.Api.Models.Models.API.Result.Verification;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/verifications")]
    public sealed class VerificationsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public VerificationsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        public Task<EmailVerificationStartResult> VerifyEmailStartAsync(int userId, string emailAddress, CancellationToken cancellationToken=default)
        {
            return PostAsync<EmailVerificationStartResult>(CreateRequestUrlWithRouteParameters($"email/{userId}/{emailAddress}"),null,cancellationToken);
        }

        public Task<MobilePhoneVerificationStartResult> VerifyMobilePhoneStart(int userId, string mobilePhoneNumber, CancellationToken cancellationToken = default)
        {
            return PostAsync<MobilePhoneVerificationStartResult>(CreateRequestUrlWithRouteParameters($"mobilephone/{userId:int}/{mobilePhoneNumber}"), null, cancellationToken);

        }

        public Task<MobilePhoneVerificationStartResult> VerifyCurrentUserMobilePhoneStart(string mobilePhoneNumber, CancellationToken cancellationToken =default)
        {
            return PostAsync<MobilePhoneVerificationStartResult>(CreateRequestUrlWithRouteParameters($"mobilephone/{mobilePhoneNumber}"), null, cancellationToken);
        }
    }
}
