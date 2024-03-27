using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/productstock")]
    public sealed class ProductStockWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ProductStockWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ProductStockModel>> GetAsync(ProductsStockFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ProductStockModel>>(parameters, ct);
        }

        public Task<UpdateResult> UpdateAsync(ProductStockModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<ProductStockModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ProductStockModel>(parameters, ct);
        }

        #endregion
    }
}
