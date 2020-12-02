using Gizmo.Web.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/products")]                                                                            
    public class ProductsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR

        public ProductsWebApiClient(HttpClient client) : base(client)
        {

        }

        #endregion

        public Task<PagedList<Product>> GetAsync(CancellationToken ct =default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<Product>> GetAsync(ProductGroupsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<Product>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(Product product,CancellationToken ct=default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(product),ct);
        }

        public Task<CreateResult> PutAsync(Product product, CancellationToken ct = default)
        {
            return PutAsync<CreateResult>(product, ct);
        }

        public Task<Product> FindAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<Product>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<Product> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<Product>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<IEnumerable<BundleProduct>> GetBundlesAsync(int bundleId, CancellationToken ct = default)
        {            
            return GetAsync<IEnumerable<BundleProduct>>(CreateRequestUrlWithRouteParameters($"bundle/{bundleId}/bundledproducts"), ct);
        }

        public Task<BundleProduct> AddProductToBundleAsync(int bundleId, BundleProduct bundleProduct, CancellationToken ct = default)
        {
            return PostAsync<BundleProduct>(CreateRequestUrlWithRouteParameters($"bundle/{bundleId}/bundledproducts"), bundleProduct, ct);
        }

    }
}
