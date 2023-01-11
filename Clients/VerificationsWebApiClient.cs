using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
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

        public Task<VerificationStartResultModelEmail> VerifyEmailStartAsync(int userId, string emailAddress, CancellationToken cancellationToken=default)
        {
            return PostAsync<VerificationStartResultModelEmail>(CreateRequestUrlWithRouteParameters($"email/{userId}/{emailAddress}"),null,cancellationToken);
        }

        public Task<VerificationStartResultModelMobilePhone> VerifyMobilePhoneStart(int userId, string mobilePhoneNumber, CancellationToken cancellationToken = default)
        {
            return PostAsync<VerificationStartResultModelMobilePhone>(CreateRequestUrlWithRouteParameters($"mobilephone/{userId:int}/{mobilePhoneNumber}"), null, cancellationToken);

        }

        public Task<VerificationStartResultModelMobilePhone> VerifyCurrentUserMobilePhoneStart(string mobilePhoneNumber, CancellationToken cancellationToken =default)
        {
            return PostAsync<VerificationStartResultModelMobilePhone>(CreateRequestUrlWithRouteParameters($"mobilephone/{mobilePhoneNumber}"), null, cancellationToken);
        }
    }
}
