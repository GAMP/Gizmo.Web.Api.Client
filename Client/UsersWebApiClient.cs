using Gizmo.Web.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/users")]
    public class UsersWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        
        public UsersWebApiClient(HttpClient client) : base(client)
        {

        }

        #endregion

        #region Users
        public Task<PagedList<User>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<User>> GetAsync(UsersFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<User>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(UserModelCreate user, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), user, ct);
        }

        public Task<UpdateResult> UpdateAsync(UserModelUpdate user, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), user, ct);
        }

        public Task<User> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<User>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
        #endregion

        #region User Attribute
        public Task<IEnumerable<UserAttribute>> GetUserAttributeAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<UserAttribute>>(CreateRequestUrlWithRouteParameters($"{id}/attributes"), ct);
        }

        public Task<CreateResult> CreateUserAtrributeAsync(int id, UserAttributeModelCreate userAttributeModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"{id}/attributes"), userAttributeModelCreate, ct);
        }

        public Task<UpdateResult> UpdateUserAttributeAsync(UserAttributeModelUpdate userAttributeModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters("attributes"), userAttributeModelUpdate, ct);
        }

        public Task<DeleteResult> DeleteUserAttributeAsync(int id, int userAttributeId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}/attributes/{userAttributeId}"), ct);
        }
        #endregion
    }
}
