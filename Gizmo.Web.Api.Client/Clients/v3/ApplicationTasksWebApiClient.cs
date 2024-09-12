using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/applicationtasks")]
    public sealed class ApplicationTasksWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationTasksWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ApplicationTaskModel>> GetAsync(ApplicationTasksFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ApplicationTaskModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationTaskModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationTaskModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<ApplicationTaskModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ApplicationTaskModel>(parameters, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<IEnumerable<ApplicationTaskUsageModel>> GetUsagesAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "usages"]);
            return GetAsync<IEnumerable<ApplicationTaskUsageModel>>(parameters, ct);
        }

        public Task<UpdateResult> UnassignAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "unassign"]);
            return PutAsync<UpdateResult>(parameters, ct);
        }

        #endregion
    }
}
