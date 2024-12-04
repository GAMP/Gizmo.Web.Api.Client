using System.Net.Http;
using Gizmo.Web.Api.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/stock")]
    public sealed class StockWebApiClient : WebApiClientBase
    {
        public StockWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
           base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<StockModel>> GetAsync(StockFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<StockModel>>(parameters, ct);
        }

        public Task<StockModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<StockModel>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(StockModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(StockModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<DeleteResult> UndeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "undelete"]);
            return PutAsync<DeleteResult>(parameters, null, ct);
        }

        public async Task<UpdateResult> RenameAsync(int id, string name, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "name"]);
            return await PutAsync<UpdateResult>(parameters, name, cancellationToken).ConfigureAwait(false);
        }

        public async Task<ExistResult> NameExistAsync(string name, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["name", name, "exist"]);
            return await GetAsync<ExistResult>(parameters, cancellationToken).ConfigureAwait(false);
        }

        public async Task<ExistResult> NameExistAsync(string name, int branchId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["name", name, "branch", branchId, "exist"]);
            return await GetAsync<ExistResult>(parameters, cancellationToken).ConfigureAwait(false);
        }
    }
}
