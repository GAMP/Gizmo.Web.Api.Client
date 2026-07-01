using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/schedules")]
    public sealed class SchedulesWebApiClient : WebApiClientBase
    {
        public SchedulesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public async Task<PagedList<ScheduleModel>> GetAsync(ScheduleFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return await GetAsync<PagedList<ScheduleModel>>(parameters, cancellationToken).ConfigureAwait(false);
        }

        public async Task<ScheduleModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return await GetAsync<ScheduleModel>(parameters, cancellationToken).ConfigureAwait(false);
        }

        public async Task<UpdateResult> EnableAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "enable"]);
            return await PutAsync<UpdateResult>(parameters, null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<UpdateResult> DisableAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "disable"]);
            return await PutAsync<UpdateResult>(parameters, null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return await DeleteAsync<DeleteResult>(parameters, cancellationToken).ConfigureAwait(false);
        }

        public async Task<UpdateResult> RenameAsync(int id, string name, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "name"]);
            return await PutAsync<UpdateResult>(parameters, name, cancellationToken).ConfigureAwait(false);
        }

        public async Task<ExistResult> NameExistAsync(string name, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["name", "exists"], new Dictionary<string, string> { ["name"] = name });
            return await GetAsync<ExistResult>(parameters, cancellationToken).ConfigureAwait(false);
        }

        public async Task<UpdateResult> DescriptionAsync(int id, string description, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "description"]);
            return await PutAsync<UpdateResult>(parameters, description, cancellationToken).ConfigureAwait(false);
        }

        public Task<CreateResult> CreateAsync(ScheduleReportCreateUpdateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["reports"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(int id, ScheduleReportCreateUpdateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["reports", id]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }
    }
}
