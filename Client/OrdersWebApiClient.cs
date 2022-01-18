using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
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

        public Task<PagedList<Order>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<Order>> GetAsync(OrdersFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<Order>>(filter, ct);
        }

        public Task<Order> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<Order>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<Order> GetByIdAsync(int id, GetOptions options, CancellationToken ct = default)
        {
            return GetAsync<Order>(CreateRequestUrl($"{id}", options), ct);
        }

        public Task<CalculatedOrder> CalculateUserOrderPriceAsync(int id, CalculateOrderOptionsModelBase order, CancellationToken ct = default)
        {
            return GetAsync<CalculatedOrder>(CreateRequestUrl($"calculate/user/{id}", order), ct);
        }

        public Task<CalculatedOrder> CalculateGuestOrderPriceAsync(CalculateOrderOptionsModelBase order, CancellationToken ct = default)
        {
            return GetAsync<CalculatedOrder>(CreateRequestUrl($"calculate/guest", order), ct);
        }

        public Task<CreateResult> CreateUserOrderAsync(int id, CalculateOrderOptions order, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"user/{id}"), order, ct);
        }

        public Task<CreateResult> InvoiceUserOrderAsync(int id, CalculateInvoiceOrderOptions calculateInvoiceOrderOptions, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"user/{id}/invoice"), calculateInvoiceOrderOptions, ct);
        }

        public Task<CreateResult> InvoiceGuestOrderAsync(CalculateInvoiceOrderOptions calculateInvoiceOrderOptions, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"guest/invoice"), calculateInvoiceOrderOptions, ct);
        }

        public Task<CreateResult> InvoiceOrderAsync(int id, InvoiceOrderOptions invoiceOrderOptions, CancellationToken ct = default)
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

        public Task<OrderLineDeliveredStatus> GetOrderLineDeliveredStatusAsync(int id, int orderLineId, CancellationToken ct = default)
        {
            return GetAsync<OrderLineDeliveredStatus>(CreateRequestUrlWithRouteParameters($"{id}/orderlines/{orderLineId}/delivered"), ct);
        }

        public Task<OrderLineDeliveredStatus> SetOrderLineDeliveredQuantityAsync(int id, int orderLineId, OrderLineDeliveredStatusModelUpdate orderLineDeliveredStatusModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<OrderLineDeliveredStatus>(CreateRequestUrlWithRouteParameters($"{id}/orderlines/{orderLineId}/delivered"), orderLineDeliveredStatusModelUpdate, ct);
        }

        #endregion
    }
}
