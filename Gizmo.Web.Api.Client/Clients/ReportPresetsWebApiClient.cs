using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/reportpresets")]
    public sealed class ReportPresetsWebApiClient : WebApiClientBase
    {
        public ReportPresetsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<ReportPresetModel>> GetAsync(ReportPresetFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ReportPresetModel>>(parameters, ct);
        }

        public Task<ReportPresetModel> GetAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ReportPresetModel>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(ReportPresetModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(ReportPresetModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public async Task SetDisplayOrderAsync(int id, int displayOrder, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id,"displayOrder", displayOrder]);
            await PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }
    }
}
