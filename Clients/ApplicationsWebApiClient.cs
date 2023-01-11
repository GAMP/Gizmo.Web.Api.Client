using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/applications")]
    public class ApplicationsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ApplicationModel>> GetAsync(ApplicationsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ApplicationModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationModelCreate applicationModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), applicationModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationModelUpdate applicationModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), applicationModelUpdate, ct);
        }

        public Task<ApplicationModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<ApplicationModelImage> GetApplicationImage(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationModelImage>(CreateRequestUrlWithRouteParameters($"{id}/image"), ct);
        }

        public Task<UpdateResult> UpdateApplicationImage(int id, ApplicationModelImage applicationImage, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"{id}/image"), applicationImage, ct);
        } 

        #endregion
    }
}
