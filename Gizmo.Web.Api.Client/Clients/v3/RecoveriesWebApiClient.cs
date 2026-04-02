using System;
using System.Collections.Generic;
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

        public Task<IReadOnlyList<VerificationProviderModel>> GetProvidersAsync(int? userId = null, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["providers"], new { userId });
            return GetAsync<IReadOnlyList<VerificationProviderModel>>(parameters, cancellationToken);
        }

        public Task<VerificationStartResultModel> PasswordRecoveryStartAsync(OperatorPasswordRecoveryStartModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["password", "start"]);
            return PostAsync<VerificationStartResultModel>(parameters, model, cancellationToken);
        }
    }
}
