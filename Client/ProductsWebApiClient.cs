using Gizmo.Web.Api.Models;
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
            return PostAsync<CreateResult>(CreateRequestUrl(product), product ,ct);
        }
    }
}
