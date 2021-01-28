using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/invoices")]
    public class InvoicesWebApiClient : WebApiClientBase
    {
        public InvoicesWebApiClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<PagedList<Invoice>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }        

        public Task<PagedList<Invoice>> GetAsync(InvoicesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<Invoice>>(filter, ct);
        }

        public Task<Invoice> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<Invoice>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<UpdateResult> UpdateAsync(int id, RefundOptions refundOptions, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"{id}/void"),refundOptions, ct);
        }
    }
}
