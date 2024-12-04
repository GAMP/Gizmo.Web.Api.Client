using System.Net.Http;
using Gizmo.Web.Api.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// User permission set web api client.
    /// </summary>
    [WebApiRoute("api/v3/userpermissionsets")]
    public sealed class UserPermissionSetWebApiClient : WebApiClientBase
    {
        public UserPermissionSetWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
           base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<UserPermissionSetModel>> GetAsync(UserPermissionSetFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<UserPermissionSetModel>>(parameters, cancellationToken);
        }

        public Task<UserPermissionSetModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<UserPermissionSetModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(UserPermissionSetModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(UserPermissionSetModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
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

        public Task<IEnumerable<UserPermissionModel>> PermissionsGetAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "permissions"]);
            return GetAsync<IEnumerable<UserPermissionModel>>(parameters, cancellationToken);
        }

        public Task<UpdateResult> PermissionsSetAsync(int id, IEnumerable<UserPermissionModel> permissions, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "permissions"]);
            return PutAsync<UpdateResult>(parameters, permissions, cancellationToken);
        }
    }
}
