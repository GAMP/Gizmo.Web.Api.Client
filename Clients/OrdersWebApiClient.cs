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
            return GetAsync<PagedList<OrderModel>>(filter, ct);
        }

        public Task<OrderModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<OrderModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<OrderModel> GetByIdAsync(int id, ModelFilterOptions options, CancellationToken ct = default)
        {
            return GetAsync<OrderModel>(CreateRequestUrl($"{id}", options), ct);
        }

        public Task<OrderCalculatedModel> CalculateUserOrderPriceAsync(int id, OrderCalculateModelOptions order, CancellationToken ct = default)
        {
            return GetAsync<OrderCalculatedModel>(CreateRequestUrl($"calculate/user/{id}", order), ct);
        }

        public Task<OrderCalculatedModel> CalculateGuestOrderPriceAsync(OrderCalculateModelOptions order, CancellationToken ct = default)
        {
            return GetAsync<OrderCalculatedModel>(CreateRequestUrl($"calculate/guest", order), ct);
        }

        public Task<CreateResult> CreateUserOrderAsync(int id, OrderCalculatePaymentModelOptions order, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"user/{id}"), order, ct);
        }

        public Task<CreateResult> InvoiceUserOrderAsync(int id, InvoiceOrderCalculateModelOptions calculateInvoiceOrderOptions, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"user/{id}/invoice"), calculateInvoiceOrderOptions, ct);
        }

        public Task<CreateResult> InvoiceGuestOrderAsync(InvoiceOrderCalculateModelOptions calculateInvoiceOrderOptions, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"guest/invoice"), calculateInvoiceOrderOptions, ct);
        }

        public Task<CreateResult> InvoiceOrderAsync(int id, InvoiceOrderModelOptions invoiceOrderOptions, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"{id}/invoice"), invoiceOrderOptions, ct);
        }

        public Task<CreateResult> InvoiceOrderAsync(int id, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"{id}/invoice"), null, ct);
        }

        public Task<UpdateResult> CancelOrderAsync(int id, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"{id}/cancel"), null, ct);
        }

        public Task<UpdateResult> CompleteOrderAsync(int id, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"{id}/complete"), null, ct);
        }

        public Task<GetResult<bool>> GetOrderDeliveredStatusAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<GetResult<bool>>(CreateRequestUrlWithRouteParameters($"{id}/delivered"), ct);
        }

        public Task<UpdateResult> SetOrderDeliveredStatusAsync(int id, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"{id}/delivered"), null, ct);
        }

        public Task<OrderLineDeliveredStatusModel> GetOrderLineDeliveredStatusAsync(int id, int orderLineId, CancellationToken ct = default)
        {
            return GetAsync<OrderLineDeliveredStatusModel>(CreateRequestUrlWithRouteParameters($"{id}/orderlines/{orderLineId}/delivered"), ct);
        }

        public Task<OrderLineDeliveredStatusModel> SetOrderLineDeliveredQuantityAsync(int id, int orderLineId, OrderLineDeliveredStatusModelUpdate orderLineDeliveredStatusModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<OrderLineDeliveredStatusModel>(CreateRequestUrlWithRouteParameters($"{id}/orderlines/{orderLineId}/delivered"), orderLineDeliveredStatusModelUpdate, ct);
        }

        #endregion
    }
}
