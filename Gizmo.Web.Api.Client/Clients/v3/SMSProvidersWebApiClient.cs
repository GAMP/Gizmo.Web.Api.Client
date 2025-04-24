using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/smsproviders")]
    public sealed class SMSProvidersWebApiClient : WebApiClientBase
    {
        public SMSProvidersWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<IEnumerable<PaymentProviderMetadataModel>> GetAsync(CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return GetAsync<IEnumerable<PaymentProviderMetadataModel>>(parameters, ct);
        }
    }
}
