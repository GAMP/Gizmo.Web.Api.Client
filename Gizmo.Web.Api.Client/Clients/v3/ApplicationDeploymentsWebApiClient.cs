using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/applicationdeployments")]
    public sealed class ApplicationDeploymentsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationDeploymentsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ApplicationDeploymentModel>> GetAsync(ApplicationDeploymentsFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ApplicationDeploymentModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationDeploymentModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationDeploymentModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<ApplicationDeploymentModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ApplicationDeploymentModel>(parameters, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<IEnumerable<ApplicationDeploymentUsageModel>> GetUsagesAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "usages"]);
            return GetAsync<IEnumerable<ApplicationDeploymentUsageModel>>(parameters, ct);
        }

        public Task<UpdateResult> UnassignAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "unassign"]);
            return PutAsync<UpdateResult>(parameters, ct);
        }

        #endregion
    }
}
