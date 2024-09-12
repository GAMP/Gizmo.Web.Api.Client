using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/applicationpersonalfiles")]
    public sealed class ApplicationPersonalFilesWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationPersonalFilesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ApplicationPersonalFileModel>> GetAsync(ApplicationPersonalFilesFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ApplicationPersonalFileModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationPersonalFileModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationPersonalFileModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<ApplicationPersonalFileModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ApplicationPersonalFileModel>(parameters, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<IEnumerable<ApplicationPersonalFileUsageModel>> GetUsagesAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "usages"]);
            return GetAsync<IEnumerable<ApplicationPersonalFileUsageModel>>(parameters, ct);
        }

        public Task<UpdateResult> UnassignAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "unassign"]);
            return PutAsync<UpdateResult>(parameters, ct);
        }

        #endregion
    }
}
