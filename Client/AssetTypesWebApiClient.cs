using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/assettypes")]
    class AssetTypesWebApiClient: WebApiClientBase
    {
        #region CONSTRUCTOR
        public AssetTypesWebApiClient(HttpClient client) : base(client)
        {

        }
        #endregion

        public Task<PagedList<AssetType>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<AssetType>> GetAsync(AssetTypesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<AssetType>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(AssetTypeModelCreate assetTypeModelCreate, CancellationToken ct= default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), assetTypeModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(AssetTypeModelUpdate assetTypeModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), assetTypeModelUpdate, ct);
        }

        public Task<AssetType> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<AssetType>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
    }
}
