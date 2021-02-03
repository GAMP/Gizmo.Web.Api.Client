using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/invoicepayments")]
    public class InvoicePaymentsWebApiClient : WebApiClientBase
    {
        public InvoicePaymentsWebApiClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<PagedList<InvoicePayment>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<InvoicePayment>> GetAsync(InvoicePaymentsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<InvoicePayment>>(filter, ct);
        }

        public Task<InvoicePayment> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<InvoicePayment>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<CreateResult> CreateAsync(InvoicePaymentModelCreate invoicePaymentModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), invoicePaymentModelCreate, ct);
        }
    }
}
