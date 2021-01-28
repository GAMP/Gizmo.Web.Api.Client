using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/applicationtasks")]
    public class ApplicationTasksWebApiClient : WebApiClientBase
    {
        public ApplicationTasksWebApiClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<PagedList<ApplicationTask>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<ApplicationTask>> GetAsync(ApplicationTasksFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ApplicationTask>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationTaskModelCreate applicationTaskModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), applicationTaskModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationTaskModelUpdate applicationTaskModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), applicationTaskModelUpdate, ct);
        }

        public Task<ApplicationTask> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationTask>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
    }
}
