using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/registrations")]
    public sealed class RegistrationsWebApiClient : WebApiClientBase
    {
        public RegistrationsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<IReadOnlyList<VerificationProviderModel>> GetProvidersAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["providers"]);
            return GetAsync<IReadOnlyList<VerificationProviderModel>>(parameters, cancellationToken);
        }

        public Task<VerificationStartResultModelBase> StartAsync(RegistrationStartModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["start"]);
            return PostAsync<VerificationStartResultModelBase>(parameters, model, cancellationToken);
        }

        public Task<AccountCreationByTokenCompleteResultCode> CompleteAsync(RegistrationCompleteModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["complete"]);
            return PostAsync<AccountCreationByTokenCompleteResultCode>(parameters, model, cancellationToken);
        }

        public Task<AccountCreationCompleteResultCode> DirectAsync(RegistrationDirectModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["direct"]);
            return PostAsync<AccountCreationCompleteResultCode>(parameters, model, cancellationToken);
        }

        public Task<TokenConfirmedResultModel> ConfirmedAsync(TokenCheckModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["confirmed"]);
            return PostAsync<TokenConfirmedResultModel>(parameters, model, cancellationToken);
        }
    }
}
