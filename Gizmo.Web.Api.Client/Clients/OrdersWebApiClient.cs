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

        public Task<PagedList<OrderModel>> GetAsync(OrdersFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<OrderModel>>(parameters, cancellationToken);
        }

        public Task<OrderModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<OrderModel>(parameters, cancellationToken);
        }

        public Task<OrderModel> GetByIdAsync(int id, ModelFilterOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { id }, options);
            return GetAsync<OrderModel>(parameters, cancellationToken);
        }

        public Task<OrderCalculatedModel> CalculateUserOrderPriceAsync(int id, OrderCalculateModelOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "calculate", "user", id }, options);
            return GetAsync<OrderCalculatedModel>(parameters, cancellationToken);
        }

        public Task<OrderCalculatedModel> CalculateGuestOrderPriceAsync(OrderCalculateModelOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "calculate", "guest" }, options);
            return GetAsync<OrderCalculatedModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateUserOrderAsync(int id, OrderCalculatePaymentModelOptions model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "user", id });
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<CreateResult> InvoiceUserOrderAsync(int id, InvoiceOrderCalculateModelOptions model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "user", id, "invoice" });
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<CreateResult> InvoiceGuestOrderAsync(InvoiceOrderCalculateModelOptions model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "guest", "invoice" });
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<CreateResult> InvoiceOrderAsync(int id, InvoiceOrderModelOptions model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { id, "invoice" });
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<CreateResult> InvoiceOrderAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { id, "invoice" });
            return PostAsync<CreateResult>(parameters, null, cancellationToken);
        }

        public Task<UpdateResult> AcceptAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "accept"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<UpdateResult> CancelAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "cancel"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<UpdateResult> CompleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "complete"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<OrderDeliveredStatusModel> DeliveredAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "delivered"]);
            return GetAsync<OrderDeliveredStatusModel>(parameters, cancellationToken);
        }

        public Task<UpdateResult> DeliverAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "delivered"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<OrderLineDeliveredStatusModel> OrderLineDeliveredAsync(int id, int orderLineId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "orderlines", orderLineId, "delivered"]);
            return GetAsync<OrderLineDeliveredStatusModel>(parameters, cancellationToken);
        }

        public Task<OrderLineDeliveredStatusModel> OrderLineDeliverAsync(int id, int orderLineId, OrderLineDeliveredStatusModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "orderlines", orderLineId, "delivered"]);
            return PutAsync<OrderLineDeliveredStatusModel>(parameters, model, cancellationToken);
        }

        public Task<ProductPriceRequestResponseModel> ProductPriceAsync(int productId, decimal quantity, int userGroupId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["product", productId , "usergroup", userGroupId, "quantity",quantity,  "price"]);
            return GetAsync<ProductPriceRequestResponseModel>(parameters, cancellationToken);
        }

        public Task<ProductPriceRequestResponseModel> ProductPriceAsync(int productId, decimal quantity, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["product", productId, "quantity", quantity, "price"]);
            return GetAsync<ProductPriceRequestResponseModel>(parameters, cancellationToken);
        }

        public Task<ProductPriceRequestResponseModel> ProductUserPriceAsync(int userId, int productId, decimal quantity, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["product", productId, "user", userId, "quantity",  quantity, "price"]);
            return GetAsync<ProductPriceRequestResponseModel>(parameters, cancellationToken);
        }
    }
}
