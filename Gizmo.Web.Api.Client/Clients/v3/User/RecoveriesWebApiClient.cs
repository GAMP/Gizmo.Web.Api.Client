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

        public Task<IReadOnlyList<AvailableVerificationMethodModel>> GetMethodsAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["methods"]);
            return GetAsync<IReadOnlyList<AvailableVerificationMethodModel>>(parameters, cancellationToken);
        }

        public Task<IReadOnlyList<AvailableVerificationMethodModel>> GetMethodsAsync(VerificationMethodValueKind valueKind, string? value, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, string> { ["valueKind"] = ((int)valueKind).ToString() };
            if (!string.IsNullOrEmpty(value))
                query["value"] = value;

            var parameters = new UriParameters(["methods"], query);
            return GetAsync<IReadOnlyList<AvailableVerificationMethodModel>>(parameters, cancellationToken);
        }

        public Task<VerificationStartResultModelBase> PasswordRecoveryStartAsync(VerificationMethodStartModelBase model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["password", "start"]);
            return PostAsync<VerificationStartResultModelBase>(parameters, model, cancellationToken);
        }
    }
}
