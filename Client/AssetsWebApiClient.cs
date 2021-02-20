using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/assets")]
    public class AssetsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public AssetsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<Asset>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<Asset>> GetAsync(AssetsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<Asset>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(AssetModelCreate asset, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), asset, ct);
        }

        public Task<UpdateResult> UpdateAsync(AssetModelUpdate assetModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), assetModelUpdate, ct);
        }

        public Task<Asset> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<Asset>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
