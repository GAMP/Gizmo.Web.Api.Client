using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
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

        public Task<PagedList<AssetModel>> GetAsync(AssetsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<AssetModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(AssetModelCreate asset, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), asset, ct);
        }

        public Task<UpdateResult> UpdateAsync(AssetModelUpdate assetModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), assetModelUpdate, ct);
        }

        public Task<AssetModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<AssetModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
