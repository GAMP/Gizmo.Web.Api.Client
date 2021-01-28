using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/applications")]
    public class ApplicationsWebApiClient : WebApiClientBase
    {
        public ApplicationsWebApiClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<PagedList<Application>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<Application>> GetAsync(ApplicationsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<Application>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationModelCreate applicationModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), applicationModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationModelUpdate applicationModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), applicationModelUpdate, ct);
        }

        public Task<Application> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<Application>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
    }
}
