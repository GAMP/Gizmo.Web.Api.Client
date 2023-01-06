using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/assettypes")]
    public class AssetTypesWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public AssetTypesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<AssetTypeModel>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<AssetTypeModel>> GetAsync(AssetTypesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<AssetTypeModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(AssetTypeModelCreate assetTypeModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), assetTypeModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(AssetTypeModelUpdate assetTypeModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), assetTypeModelUpdate, ct);
        }

        public Task<AssetTypeModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<AssetTypeModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
