using Gizmo.Web.Api.Models;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/monetaryunits")]
    public class MonetaryUnitsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public MonetaryUnitsWebApiClient(HttpClient client) : base(client)
        {

        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<MonetaryUnit>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<MonetaryUnit>> GetAsync(MonetaryUnitsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<MonetaryUnit>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(MonetaryUnitModelCreate monetaryUnitModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), monetaryUnitModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(MonetaryUnitModelUpdate monetaryUnitModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), monetaryUnitModelUpdate, ct);
        }

        public Task<MonetaryUnit> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<MonetaryUnit>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
