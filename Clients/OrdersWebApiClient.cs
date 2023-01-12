using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/orders")]
    public class OrdersWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public OrdersWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        #region FUNCTIONS

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

        public Task<OrderModel> GetByIdAsync(int id, ModelFilterOptions filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id }, filter);
            return GetAsync<OrderModel>(parameters, ct);
        }

        public Task<OrderCalculatedModel> CalculateUserOrderPriceAsync(int id, OrderCalculateModelOptions filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "calculate", "user", id }, filter);
            return GetAsync<OrderCalculatedModel>(parameters, ct);
        }

        public Task<OrderCalculatedModel> CalculateGuestOrderPriceAsync(OrderCalculateModelOptions filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "calculate", "guest" }, filter);
            return GetAsync<OrderCalculatedModel>(parameters, ct);
        }

        public Task<CreateResult> CreateUserOrderAsync(int id, OrderCalculatePaymentModelOptions order, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "user", id });
            return PostAsync<CreateResult>(parameters, order, ct);
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

        public Task<UpdateResult> CancelOrderAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "cancel" });
            return PutAsync<UpdateResult>(parameters, null, ct);
        }

        public Task<UpdateResult> CompleteOrderAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "complete" });
            return PutAsync<UpdateResult>(parameters, null, ct);
        }

        public Task<GetResult<bool>> GetOrderDeliveredStatusAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "delivered" });
            return GetAsync<GetResult<bool>>(parameters, ct);
        }

        public Task<UpdateResult> SetOrderDeliveredStatusAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "delivered" });
            return PutAsync<UpdateResult>(parameters, null, ct);
        }

        public Task<OrderLineDeliveredStatusModel> GetOrderLineDeliveredStatusAsync(int id, int orderLineId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "orderlines", orderLineId, "delivered" });
            return GetAsync<OrderLineDeliveredStatusModel>(parameters, ct);
        }

        public Task<OrderLineDeliveredStatusModel> SetOrderLineDeliveredQuantityAsync(int id, int orderLineId, OrderLineDeliveredStatusModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "orderlines", orderLineId, "delivered" });
            return PutAsync<OrderLineDeliveredStatusModel>(parameters, model, ct);
        }

        #endregion
    }
}
