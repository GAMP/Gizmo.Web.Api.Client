using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/usergroups")]
    public class UserGroupsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR        
        public UserGroupsWebApiClient(HttpClient httpClient) : base(httpClient)
        {
        }
        #endregion

        #region User Groups

        public Task<PagedList<UserGroup>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<UserGroup>> GetAsync(UserGroupsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<UserGroup>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(UserGroupModelCreate userGroup, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(),userGroup, ct);
        }

        public Task<UpdateResult> UpdateAsync(UserGroupModelUpdate userGroup, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), userGroup, ct);
        }

        public Task<UserGroup> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<UserGroup>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
        #endregion
    }
}
