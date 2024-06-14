using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/productorders")]
    public sealed class ProductOrdersWebApiClient : WebApiClientBase
    {
        public ProductOrdersWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
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

        public Task<PagedList<ActiveOrderModel>> ActiveAsync(ActiveOrdersFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["active"], filter);
            return GetAsync<PagedList<ActiveOrderModel>>(parameters, cancellationToken);
        }

        public Task<ActiveOrderModel?> ActiveAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "active"]);
            return GetAsync<ActiveOrderModel?>(parameters, cancellationToken);
        }

        public Task<OrderInvoiceResultModel> InvoiceAsync(int id, OrderInvoiceModel orderInvoiceModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "invoice"]);
            return PutAsync<OrderInvoiceResultModel>(parameters, orderInvoiceModel, cancellationToken);
        }

        public Task<UpdateResult> ProcessAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "process"]);
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

        public Task<UpdateResult> DeliverAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "delivered"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<OrderDeliveredStatusModel> DeliveredAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "delivered"]);
            return GetAsync<OrderDeliveredStatusModel>(parameters, cancellationToken);
        }

        public Task<UpdateResult> OrderLineDeliverAsync(int orderLineId, decimal quantity, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["orderlines", orderLineId, "delivered", quantity]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<UpdateResult> OrderLineDeliverAsync(int orderLineId, OrderLineDeliveredStatusModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["orderlines", orderLineId, "delivered"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<IEnumerable<OrderDeliveredStatusModel>> OrderLinesDeliveredAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "orderlines", "delivered"]);
            return GetAsync<IEnumerable<OrderDeliveredStatusModel>>(parameters, cancellationToken);
        }      

        public Task<OrderLineDeliveredStatusModel> OrderLineDeliveredAsync(int orderLineId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["orderlines", orderLineId, "delivered"]);
            return GetAsync<OrderLineDeliveredStatusModel>(parameters, cancellationToken);
        }    

        public Task<ProductPriceRequestResponseModel> ProductPriceAsync(int productId, decimal quantity, int userGroupId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["product", productId, "usergroup", userGroupId, "quantity", quantity, "price"]);
            return GetAsync<ProductPriceRequestResponseModel>(parameters, cancellationToken);
        }

        public Task<ProductPriceRequestResponseModel> ProductPriceAsync(int productId, decimal quantity, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["product", productId, "quantity", quantity, "price"]);
            return GetAsync<ProductPriceRequestResponseModel>(parameters, cancellationToken);
        }

        public Task<ProductPriceRequestResponseModel> ProductUserPriceAsync(int userId, int productId, decimal quantity, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["product", productId, "user", userId, "quantity", quantity, "price"]);
            return GetAsync<ProductPriceRequestResponseModel>(parameters, cancellationToken);
        }

        public Task<OrderInvoiceCreateResultModel> CreateAsync(OrderInvoiceModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<OrderInvoiceCreateResultModel>(UriParameters.Empty, model, cancellationToken);
        }

        public Task<OrderInvoiceCreateMultiResultModel> CreateAsync(OrderInvoiceCreateMultiModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["multi"]);
            return PostAsync<OrderInvoiceCreateMultiResultModel>(parameters, model, cancellationToken);
        }
    }
}
