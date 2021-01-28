using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/applicationlicenses")]
    public class ApplicationLicensesWebApiClient : WebApiClientBase
    {
        public ApplicationLicensesWebApiClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<PagedList<ApplicationLicense>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<ApplicationLicense>> GetAsync(ApplicationLicensesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ApplicationLicense>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationLicenseModelCreate applicationLicenseModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), applicationLicenseModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationLicenseModelUpdate applicationLicenseModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), applicationLicenseModelUpdate, ct);
        }

        public Task<ApplicationLicense> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationLicense>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
    }
}
