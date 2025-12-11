using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;
using System;
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

        public Task<CreateResult> CreateProcessAsync(TaskProcessCreateUpdateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["process"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateProcessAsync(int id, TaskProcessCreateUpdateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "process"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<CreateResult> CreateScriptAsync(TaskScriptCreateUpdateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["script"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateScriptAsync(int id, TaskScriptCreateUpdateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "script"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<CreateResult> CreateJunctionAsync(TaskJunctionCreateUpdateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["junction"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateJunctionAsync(int id, TaskJunctionCreateUpdateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "junction"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<CreateResult> CreateNotificationAsync(TaskNotificationCreateUpdateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["notification"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateNotificationAsync(int id, TaskNotificationCreateUpdateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "notification"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        #endregion
    }
}
