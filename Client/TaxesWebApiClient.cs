using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/taxes")]
    public class TaxesWebApiClient:WebApiClientBase
    {
        #region CONSTRUCTOR
        public TaxesWebApiClient(HttpClient client):base(client)
        {

        }
        #endregion

        public Task<PagedList<Tax>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<Tax>> GetAsync(TaxesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<Tax>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(TaxModelCreate taxModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), taxModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(TaxModelUpdate taxModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), taxModelUpdate, ct);
        }

        public Task<Tax> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<Tax>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
    }
}
