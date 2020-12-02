using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/hostgroups")]
    public class HostGroupsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public HostGroupsWebApiClient(HttpClient httpClient) : base(httpClient)
        {
        }
        #endregion

        public Task<PagedList<HostGroup>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<HostGroup>> GetAsync(HostGroupsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<HostGroup>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(HostGroup hostGroup, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(hostGroup, ct);
        }

        public Task<CreateResult> PutAsync(HostGroup hostGroup, CancellationToken ct = default)
        {
            return PutAsync<CreateResult>(hostGroup, ct);
        }
        public Task<HostGroup> FindAsync(int id, CancellationToken ct = default)
        {           
            return GetAsync<HostGroup>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<HostGroup> DeleteAsync(int id, CancellationToken ct = default)
        {          
            return DeleteAsync<HostGroup>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
    }
}
