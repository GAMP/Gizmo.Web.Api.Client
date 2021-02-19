using Gizmo.Web.Api.Models;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/applicationcategories")]
    public class ApplicationCategoriesWebApiClient:WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationCategoriesWebApiClient(HttpClient client):base(client)
        {

        }
        #endregion

        #region FUNCTIONS
        
        public Task<PagedList<ApplicationCategory>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<ApplicationCategory>> GetAsync(ApplicationCategoriesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ApplicationCategory>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationCategoryModelCreate applicationCategoryModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), applicationCategoryModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationCategoryModelUpdate applicationCategoryModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), applicationCategoryModelUpdate, ct);
        }

        public Task<ApplicationCategory> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationCategory>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        } 

        #endregion
    }
}
