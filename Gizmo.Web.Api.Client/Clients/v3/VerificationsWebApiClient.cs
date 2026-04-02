using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/verifications")]
    public sealed class VerificationsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public VerificationsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        public Task<IReadOnlyList<VerificationProviderModel>> GetProvidersAsync(VerificationPurpose purpose, int? userId = null, CancellationToken ct = default)
        {
            var parameters = new UriParameters(["providers"], new { purpose, userId });
            return GetAsync<IReadOnlyList<VerificationProviderModel>>(parameters, ct);
        }

        public Task<VerificationStartResultModel> PhoneVerificationStartAsync(OperatorPhoneVerificationStartModel model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(["phone", "start"]);
            return PostAsync<VerificationStartResultModel>(parameters, model, ct);
        }

        public Task<VerificationStartResultModel> EmailVerificationStartAsync(OperatorEmailVerificationStartModel model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(["email", "start"]);
            return PostAsync<VerificationStartResultModel>(parameters, model, ct);
        }
    }
}
