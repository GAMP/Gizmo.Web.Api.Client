using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/reportpresets")]
    public sealed class ReportPresetsWebApiClient : WebApiClientBase
    {
        public ReportPresetsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public async Task<PagedList<ReportPresetModel>> GetAsync(ReportPresetFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return await GetAsync<PagedList<ReportPresetModel>>(parameters, ct).ConfigureAwait(false);
        }

        public async Task<ReportPresetModel> GetAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return await GetAsync<ReportPresetModel>(parameters, ct).ConfigureAwait(false);
        }

        public async Task<CreateResult> CreateAsync(ReportPresetModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return await PostAsync<CreateResult>(parameters, model, ct).ConfigureAwait(false);
        }

        public async Task<UpdateResult> UpdateAsync(ReportPresetModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return await PutAsync<UpdateResult>(parameters, model, ct).ConfigureAwait(false);
        }

        public async Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return await DeleteAsync<DeleteResult>(parameters, ct).ConfigureAwait(false);
        }

        public async Task<UpdateResult> SetDisplayOrderAsync(int id, int displayOrder, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "displayOrder", displayOrder]);
            return await PutAsync<UpdateResult>(parameters, null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<UpdateResult> RenameAsync(int id, string name, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "name", name]);
            return await PutAsync<UpdateResult>(parameters, null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<ExistResult> NameExistAsync(string name, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["name", name, "exist"]);
            return await GetAsync<ExistResult>(parameters, cancellationToken).ConfigureAwait(false);
        }
    }
}
