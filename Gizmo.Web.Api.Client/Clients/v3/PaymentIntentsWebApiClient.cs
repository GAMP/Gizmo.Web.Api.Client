using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v3/paymentintents")]
    public sealed class PaymentIntentsWebApiClient : WebApiClientBase
    {
        public PaymentIntentsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<PaymentIntentModel>> GetAsync(PaymentIntentFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<PaymentIntentModel>>(parameters, cancellationToken);
        }

        public Task<PaymentIntentModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<PaymentIntentModel>(parameters, cancellationToken);
        }

        public Task<PaymentIntentModel> GetAsync(Guid identifier, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([identifier]);
            return GetAsync<PaymentIntentModel>(parameters, cancellationToken);
        }

        public Task<PaymentIntentCreateResultModel> CreateAsync(PaymentIntentCreateParametersDepositModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<PaymentIntentCreateResultModel>(parameters, model, cancellationToken);
        }

    }
}
