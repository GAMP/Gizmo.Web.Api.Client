using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/orders")]
    public sealed class OrdersWebApiClient : WebApiClientBase
    {
        public OrdersWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }

        public Task<PagedList<OrderModel>> GetAsync(OrdersFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<OrderModel>>(parameters, ct);
        }

        public Task<OrderModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<OrderModel>(parameters, ct);
        }

        public Task<OrderModel> GetByIdAsync(int id, ModelFilterOptions options, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id }, options);
            return GetAsync<OrderModel>(parameters, ct);
        }

        public Task<OrderCalculatedModel> CalculateUserOrderPriceAsync(int id, OrderCalculateModelOptions options, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "calculate", "user", id }, options);
            return GetAsync<OrderCalculatedModel>(parameters, ct);
        }

        public Task<OrderCalculatedModel> CalculateGuestOrderPriceAsync(OrderCalculateModelOptions options, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "calculate", "guest" }, options);
            return GetAsync<OrderCalculatedModel>(parameters, ct);
        }

        public Task<CreateResult> CreateUserOrderAsync(int id, OrderCalculatePaymentModelOptions model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "user", id });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<CreateResult> InvoiceUserOrderAsync(int id, InvoiceOrderCalculateModelOptions model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "user", id, "invoice" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<CreateResult> InvoiceGuestOrderAsync(InvoiceOrderCalculateModelOptions model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "guest", "invoice" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<CreateResult> InvoiceOrderAsync(int id, InvoiceOrderModelOptions model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "invoice" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<CreateResult> InvoiceOrderAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "invoice" });
            return PostAsync<CreateResult>(parameters, null, ct);
        }

        public Task<UpdateResult> AcceptAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "accept"]);
            return PutAsync<UpdateResult>(parameters, null, ct);
        }

        public Task<UpdateResult> CancelAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "cancel"]);
            return PutAsync<UpdateResult>(parameters, null, ct);
        }

        public Task<UpdateResult> CompleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "complete"]);
            return PutAsync<UpdateResult>(parameters, null, ct);
        }

        public Task<OrderDeliveredStatusModel> DeliveredAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "delivered"]);
            return GetAsync<OrderDeliveredStatusModel>(parameters, ct);
        }

        public Task<UpdateResult> DeliverAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "delivered"]);
            return PutAsync<UpdateResult>(parameters, null, ct);
        }

        public Task<OrderLineDeliveredStatusModel> OrderLineDeliveredAsync(int id, int orderLineId, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "orderlines", orderLineId, "delivered"]);
            return GetAsync<OrderLineDeliveredStatusModel>(parameters, ct);
        }

        public Task<OrderLineDeliveredStatusModel> OrderLineDeliverAsync(int id, int orderLineId, OrderLineDeliveredStatusModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "orderlines", orderLineId, "delivered"]);
            return PutAsync<OrderLineDeliveredStatusModel>(parameters, model, ct);
        }

    }
}
