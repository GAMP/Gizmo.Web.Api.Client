using Gizmo.Web.Api.Models;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/productsstock")]
    public class ProductsStockWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ProductsStockWebApiClient(HttpClient httpClient) : base(httpClient)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ProductStock>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<ProductStock>> GetAsync(ProductsStockFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ProductStock>>(filter, ct);
        }

        public Task<UpdateResult> UpdateAsync(ProductStockModelUpdate productStockModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), productStockModelUpdate, ct);
        }

        public Task<ProductStock> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ProductStock>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
