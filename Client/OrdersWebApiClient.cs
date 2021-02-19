using Gizmo.Web.Api.Models;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/orders")]
    public class OrdersWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public OrdersWebApiClient(HttpClient client) : base(client)
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

        public Task<CalculatedOrder> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<CalculatedOrder>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
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

        public Task<GetResult<bool>> GetOrderDeliveredStatusAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<GetResult<bool>>(CreateRequestUrlWithRouteParameters($"{id}/delivered"), ct);
        }

        public Task<UpdateResult> SetOrderDeliveredStatusAsync(int id, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"{id}/delivered"), ct);
        }

        public Task<OrderLineDeliveredStatus> GetOrderLineDeliveredStatusAsync(int id, int orderLineId, CancellationToken ct = default)
        {
            return GetAsync<OrderLineDeliveredStatus>(CreateRequestUrlWithRouteParameters($"{id}/orderlines/{orderLineId}/delivered"), ct);
        }

        public Task<OrderLineDeliveredStatus> SetOrderLineDeliveredQuantityAsync(int id, int orderLineId, OrderLineDeliveredStatusModelUpdate orderLineDeliveredStatusModelUpdate, CancellationToken ct = default)
        {
            return GetAsync<OrderLineDeliveredStatus>(CreateRequestUrlWithRouteParameters($"{id}/orderlines/{orderLineId}/delivered"), ct);
        }

        #endregion
    }
}
