using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Models.API.Request;
using Gizmo.Web.Api.Models.Models.API.Request.Application;
using Gizmo.Web.Api.Models.Models.API.Request.Application.Model;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
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

        public Task<PagedList<Application>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<Application>> GetAsync(ApplicationsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<Application>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationModelCreate applicationModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), applicationModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationModelUpdate applicationModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), applicationModelUpdate, ct);
        }

        public Task<Application> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<Application>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<ApplicationImage> GetApplicationImage(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationImage>(CreateRequestUrlWithRouteParameters($"{id}/image"), ct);
        }

        public Task<UpdateResult> UpdateApplicationImage(int id, ApplicationImage applicationImage, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"{id}/image"), applicationImage, ct);
        } 

        #endregion
    }
}
