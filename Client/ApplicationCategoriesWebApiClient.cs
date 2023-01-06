using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/applicationcategories")]
    public class ApplicationCategoriesWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationCategoriesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ApplicationCategoryModel>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<ApplicationCategoryModel>> GetAsync(ApplicationCategoriesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ApplicationCategoryModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationCategoryModelCreate applicationCategoryModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), applicationCategoryModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationCategoryModelUpdate applicationCategoryModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), applicationCategoryModelUpdate, ct);
        }

        public Task<ApplicationCategoryModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationCategoryModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
