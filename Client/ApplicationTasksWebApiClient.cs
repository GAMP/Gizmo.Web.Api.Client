using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/applicationtasks")]
    public class ApplicationTasksWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationTasksWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ApplicationTaskModel>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<ApplicationTaskModel>> GetAsync(ApplicationTasksFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ApplicationTaskModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationTaskModelCreate applicationTaskModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), applicationTaskModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationTaskModelUpdate applicationTaskModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), applicationTaskModelUpdate, ct);
        }

        public Task<ApplicationTaskModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationTaskModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        } 

        #endregion
    }
}
