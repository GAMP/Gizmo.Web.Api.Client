using System.Net.Http;
using Gizmo.Web.Api.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/companions")]
    public sealed class CompanionWebApiClient : WebApiClientBase
    {
        public CompanionWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<CompanionModel>> GetAsync(CompanionFilterModel filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<CompanionModel>>(parameters, ct);
        }

        public Task<CompanionModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<CompanionModel>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(CompanionModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(CompanionModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<IEnumerable<CompanionConnectionInfoModel>> ConnectionsAsync(CancellationToken ct = default)
        {
            var parameters = new UriParameters(["connections"]);
            return GetAsync<IEnumerable<CompanionConnectionInfoModel>>(parameters, ct);
        }
    }
}
