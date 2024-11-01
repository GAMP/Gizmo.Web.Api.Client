using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/usergroups")]
    public sealed class UserGroupsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR        
        public UserGroupsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<UserGroupModel>> GetAsync(UserGroupsFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<UserGroupModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(UserGroupModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(UserGroupModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<UserGroupModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<UserGroupModel>(parameters, ct);
        }

        public Task<UserGroupDeleteResultModel> DeleteAsync(int id, UserGroupDeleteOptionsModel options, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id], options);
            return DeleteAsync<UserGroupDeleteResultModel>(parameters, ct);
        }

        public Task<IEnumerable<UserGroupDisallowedHostGroupModel>> GetDisallowedHostGroupsAsync(int userGroupId, CancellationToken ct = default)
        {
            var parameters = new UriParameters([userGroupId, "disallowedhostgroups"]);
            return GetAsync<IEnumerable<UserGroupDisallowedHostGroupModel>>(parameters, ct);
        }

        #endregion
    }
}
