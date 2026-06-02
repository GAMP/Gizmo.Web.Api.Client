using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Collections.Generic;
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

        public Task<PagedList<RegisterModel>> GetAsync(RegistersFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<RegisterModel>>(parameters, cancellationToken);
        }

        public Task<RegisterModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<RegisterModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(RegisterModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(RegisterModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<DeleteResult> UndeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "undelete"]);
            return PutAsync<DeleteResult>(parameters, null, cancellationToken);
        }

        public Task<RegisterModel> CurrentAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["current"]);
            return GetAsync<RegisterModel>(parameters, cancellationToken);
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

        public async Task<ExistResult> NameExistAsync(string name, int branchId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["name", "branches", branchId, "exists"], new Dictionary<string, string> { ["name"] = name });
            return await GetAsync<ExistResult>(parameters, cancellationToken).ConfigureAwait(false);
        }
    }
}
