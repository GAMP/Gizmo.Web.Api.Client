using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/productgroups")]
    public sealed class ProductGroupsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ProductGroupsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        #region FUNCTIONS
        
        public Task<PagedList<ProductGroupModel>> GetAsync(ProductGroupsFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ProductGroupModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(ProductGroupModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(ProductGroupModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<ProductGroupModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ProductGroupModel>(parameters, ct);
        }

        public Task<ProductGroupDeleteResultModel> DeleteAsync(int id, ProductGroupDeleteOptionsModel options, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id], options);
            return DeleteAsync<ProductGroupDeleteResultModel>(parameters, ct);
        }

        public async Task<ExistResult> NameExistAsync(string name, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["name", "exists"], new Dictionary<string, string> { ["name"] = name });
            return await GetAsync<ExistResult>(parameters, cancellationToken).ConfigureAwait(false);
        }

        #endregion
    }
}
