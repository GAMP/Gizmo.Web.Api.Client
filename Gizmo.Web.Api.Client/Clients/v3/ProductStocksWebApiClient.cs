using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/productstocks")]
    public sealed class ProductStocksWebApiClient : WebApiClientBase
    {
        public ProductStocksWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public async Task<PagedList<ProductStockLevelModel>> GetAsync(ProductStockLevelFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return await GetAsync<PagedList<ProductStockLevelModel>>(parameters, cancellationToken);
        }

        public async Task<ProductStockModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id]);
            return await GetAsync<ProductStockModel>(parameters, cancellationToken);
        }

        public async Task<ProductStockModel> GetByIdAsync(int id, int stockId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "stockId", stockId]);
            return await GetAsync<ProductStockModel>(parameters, cancellationToken);
        }

        public async Task<UpdateResult> SetAsync(int id, decimal amount, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "set", amount]);
            return await PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public async Task<UpdateResult> SetAsync(int id, int stockId, decimal amount, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "stockId", stockId, "set", amount]);
            return await PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public async Task<UpdateResult> AddAsync(int id, decimal amount, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "add", amount]);
            return await PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public async Task<UpdateResult> AddAsync(int id, int stockId, decimal amount, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, stockId, "add", amount]);
            return await PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public async Task<UpdateResult> RemoveAsync(int id, decimal amount, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "remove", amount]);
            return await PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public async Task<UpdateResult> RemoveAsync(int id, int stockId, decimal amount, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, stockId, "remove", amount]);
            return await PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public async Task<UpdateResult> TransactionAsync(int id, ProductStockTransactionCreateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "transaction"]);
            return await PostAsync<UpdateResult>(parameters, model, cancellationToken);
        }
    }
}
