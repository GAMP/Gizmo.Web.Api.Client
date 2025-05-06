using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/paymentproviders")]
    public sealed class PaymentProvidersWebApiClient : WebApiClientBase
    {
        public PaymentProvidersWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<IEnumerable<PaymentProviderMetadataModel>> GetAsync(CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return GetAsync<IEnumerable<PaymentProviderMetadataModel>>(parameters, ct);
        }

        public Task<PaymentProviderMetadataModel> GetByGuidAsync(Guid providerGuid, CancellationToken ct = default)
        {
            var parameters = new UriParameters([providerGuid]);
            return GetAsync<PaymentProviderMetadataModel>(parameters, ct);
        }
    }
}
