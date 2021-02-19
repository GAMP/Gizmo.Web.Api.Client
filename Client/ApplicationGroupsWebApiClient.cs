using Gizmo.Web.Api.Models;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/applicationgroups")]
    public class ApplicationGroupsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationGroupsWebApiClient(HttpClient client) : base(client)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ApplicationGroup>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<ApplicationGroup>> GetAsync(ApplicationGroupsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ApplicationGroup>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationGroupModelCreate applicationGroupModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), applicationGroupModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationGroupModelUpdate applicationGroupModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), applicationGroupModelUpdate, ct);
        }

        public Task<ApplicationGroup> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationGroup>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        } 

        #endregion
    }
}
