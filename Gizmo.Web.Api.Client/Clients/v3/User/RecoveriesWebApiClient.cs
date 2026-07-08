using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    [UnsecureWebApiClient()]
    [WebApiRoute("api/user/v3/recoveries")]
    public sealed class RecoveriesWebApiClient : WebApiClientBase
    {
        public RecoveriesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<IReadOnlyList<VerificationProviderModel>> GetProvidersAsync(string? matchValue = null, CancellationToken cancellationToken = default)
        {
            UriParameters parameters;
            if (!string.IsNullOrEmpty(matchValue))
            {
                var query = new Dictionary<string, string> { ["matchValue"] = matchValue };
                parameters = new UriParameters(["providers"], query);
            }
            else
            {
                parameters = new UriParameters(["providers"]);
            }
            return GetAsync<IReadOnlyList<VerificationProviderModel>>(parameters, cancellationToken);
        }

        public Task<VerificationStartResultModel> PasswordRecoveryStartAsync(UserPasswordRecoveryStartModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["password", "start"]);
            return PostAsync<VerificationStartResultModel>(parameters, model, cancellationToken);
        }
    }
}
