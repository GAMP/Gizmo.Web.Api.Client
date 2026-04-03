using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    [WebApiRoute("api/user/v3/verifications")]
    public sealed class VerificationsWebApiClient : WebApiClientBase
    {
        public VerificationsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<IReadOnlyList<VerificationProviderModel>> GetProvidersAsync(VerificationPurpose purpose, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, string> { ["purpose"] = ((int)purpose).ToString() };
            var parameters = new UriParameters(["providers"], query);
            return GetAsync<IReadOnlyList<VerificationProviderModel>>(parameters, cancellationToken);
        }

        public Task<VerificationStartResultModel> PhoneVerificationStartAsync(UserPhoneVerificationStartModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["phone", "start"]);
            return PostAsync<VerificationStartResultModel>(parameters, model, cancellationToken);
        }

        public Task<VerificationStartResultModel> EmailVerificationStartAsync(UserEmailVerificationStartModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["email", "start"]);
            return PostAsync<VerificationStartResultModel>(parameters, model, cancellationToken);
        }
    }
}
