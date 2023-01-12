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

        public Task<VerificationStartResultModelEmail> VerifyEmailStartAsync(int userId, string emailAddress, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "email", userId, emailAddress });
            return PostAsync<VerificationStartResultModelEmail>(parameters, null, ct);
        }

        public Task<VerificationStartResultModelMobilePhone> VerifyMobilePhoneStart(int userId, string mobilePhoneNumber, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "mobilephone", userId, mobilePhoneNumber });
            return PostAsync<VerificationStartResultModelMobilePhone>(parameters, null, ct);
        }

        public Task<VerificationStartResultModelMobilePhone> VerifyCurrentUserMobilePhoneStart(string mobilePhoneNumber, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "mobilephone", mobilePhoneNumber });
            return PostAsync<VerificationStartResultModelMobilePhone>(parameters, null, ct);
        }
    }
}
