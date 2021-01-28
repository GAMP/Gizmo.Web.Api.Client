using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/applicationenterprises")]
    public class ApplicationEnterprisesWebApiClient:WebApiClientBase
    {
        public ApplicationEnterprisesWebApiClient(HttpClient client) : base(client)
        {

        }

        public Task<PagedList<ApplicationEnterprise>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<ApplicationEnterprise>> GetAsync(ApplicationEnterprisesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ApplicationEnterprise>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationEnterpriseModelCreate applicationEnterpriseModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), applicationEnterpriseModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationEnterpriseModelUpdate applicationEnterpriseModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), applicationEnterpriseModelUpdate, ct);
        }

        public Task<ApplicationEnterprise> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationEnterprise>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
    }
}
