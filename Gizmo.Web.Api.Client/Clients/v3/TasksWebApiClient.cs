using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/tasks")]
    public sealed class TasksWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public TasksWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<TaskModel>> GetAsync(TaskFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<TaskModel>>(parameters, ct);
        }

        public Task<TaskModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<TaskModel>(parameters, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<PagedList<TaskCountersModel>> GetCountersAsync(TaskCountersFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(["counters"], filter);
            return GetAsync<PagedList<TaskCountersModel>>(parameters, ct);
        }

        #endregion
    }
}
