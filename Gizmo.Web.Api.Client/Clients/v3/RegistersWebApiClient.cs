using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/registers")]
    public sealed class RegistersWebApiClient : WebApiClientBase
    {
        public RegistersWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<RegisterModel>> GetAsync(RegistersFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<RegisterModel>>(parameters, ct);
        }

        public Task<RegisterModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<RegisterModel>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(RegisterModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(RegisterModelUpdate model, CancellationToken ct = default)
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

        public Task<RegisterModel> CurrentAsync(CancellationToken ct = default)
        {
            var parameters = new UriParameters(new[] { "current" });
            return GetAsync<RegisterModel>(parameters, ct);
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
