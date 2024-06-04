using System.Net.Http;
using Gizmo.Web.Api.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/waitinglines")]
    public sealed class WaitingLinesWebApiClient : WebApiClientBase
    {
        public WaitingLinesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<WaitingLineModel>> GetAsync(WaitingLinesFilterModel filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<WaitingLineModel>>(parameters, cancellationToken);
        }

        public Task<WaitingLineEntryModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["id", id]);
            return GetAsync<WaitingLineEntryModel>(parameters, cancellationToken);
        }

        public Task<UpdateResult> SetAsync(int id, WaitingLineParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["id", id]);
            return PostAsync<UpdateResult>(parameters, parametersModel, cancellationToken);
        }

        public Task<IEnumerable<WaitingLinePriorityModel>> PrioritiesGetAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["usergroups", "priorities"]);
            return GetAsync<IEnumerable<WaitingLinePriorityModel>>(parameters, cancellationToken);
        }

        public Task<UpdateResult> PrioritiesSetAsync(IEnumerable<WaitingLinePriorityModel> priorities, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["usergroups", "priorities"]);
            return PostAsync<UpdateResult>(parameters, priorities, cancellationToken);
        }

        public Task<PagedList<WaitingLineEntryModel>> EntriesAsync(WaitingLineEntryFilterModel filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["entries"], filter);
            return GetAsync<PagedList<WaitingLineEntryModel>>(parameters, cancellationToken);
        }

        public Task<WaitingLineEntryModel> EntryAsync(int entryId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["entries", entryId]);
            return GetAsync<WaitingLineEntryModel>(parameters, cancellationToken);
        }

        public Task UserAddAsync(int userId, int hostGroupId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["users", userId, "hostgroups", hostGroupId]);
            return PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task UserAddAsync(int userId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["users", userId]);
            return PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task UserRemoveAsync(int userId, int hostGroupId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["users", userId, "hostgroups", hostGroupId]);
            return DeleteAsync<UpdateResult>(parameters, cancellationToken);
        }

        public Task UserRemoveAsync(int userId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["users", userId]);
            return DeleteAsync<UpdateResult>(parameters, cancellationToken);
        }

        public Task<UpdateResult> EntryMoveAsync(int entryId, WaitingLineMoveParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["entries", entryId, "move"]);
            return PostAsync<UpdateResult>(parameters, parametersModel, cancellationToken);
        }
    }
}
