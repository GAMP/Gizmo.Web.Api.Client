using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/usergroups")]
    public class UserGroupsWebApiClient : WebApiClientBase
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
            return GetAsync<PagedList<UserGroupModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(UserGroupModelCreate userGroup, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), userGroup, ct);
        }

        public Task<UpdateResult> UpdateAsync(UserGroupModelUpdate userGroup, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), userGroup, ct);
        }

        public Task<UserGroupModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<UserGroupModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
