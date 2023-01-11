using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/productsstock")]
    public class ProductsStockWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ProductsStockWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ProductStockModel>> GetAsync(ProductsStockFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ProductStockModel>>(filter, ct);
        }

        public Task<UpdateResult> UpdateAsync(ProductStockModelUpdate productStockModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), productStockModelUpdate, ct);
        }

        public Task<ProductStockModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ProductStockModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
