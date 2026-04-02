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

        public Task<VerificationStartResultModel> StartAsync(RegistrationStartModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["start"]);
            return PostAsync<VerificationStartResultModel>(parameters, model, cancellationToken);
        }
    }
}
