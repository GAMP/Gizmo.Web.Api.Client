using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/applicationdeployments")]
    public class ApplicationDeploymentsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationDeploymentsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS
        
        public Task<PagedList<ApplicationDeploymentModel>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<ApplicationDeploymentModel>> GetAsync(ApplicationDeploymentsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ApplicationDeploymentModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationDeploymentModelCreate applicationDeploymentModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), applicationDeploymentModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationDeploymentModelUpdate applicationDeploymentModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), applicationDeploymentModelUpdate, ct);
        }

        public Task<ApplicationDeploymentModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationDeploymentModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        } 

        #endregion
    }
}
