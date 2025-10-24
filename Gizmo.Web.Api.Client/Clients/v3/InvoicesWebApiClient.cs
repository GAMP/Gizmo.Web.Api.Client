using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Abstractions;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/invoices")]
    public sealed class InvoicesWebApiClient : WebApiClientBase
    {
        public InvoicesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<InvoiceModel>> GetAsync(InvoicesFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<InvoiceModel>>(parameters, cancellationToken);
        }

        public Task<InvoiceModel> GetByIdAsync(int id, ModelFilterOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { id }, options);
            return GetAsync<InvoiceModel>(parameters, cancellationToken);
        }

        public Task<UpdateResult> VoidAsync(int id, RefundModel? model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "void"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<decimal> LineQuantityAsync(int invoiceLineId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["lines", invoiceLineId, "quantity"]);
            return GetAsync<decimal>(parameters, cancellationToken);
        }

        public Task<UsageSessionActiveInvoiceResultModel> UsageSessionActiveInvoiceAsync(int userId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", userId, "usagesession", "active", "invoice"]);
            return PostAsync<UsageSessionActiveInvoiceResultModel>(parameters, null, cancellationToken);
        }

        public Task<UpdateResult> CloseBalanceAsync(int userId, CloseBalanceModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", userId, "balance", "close"]);
            return PostAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<InvoicePaymentsCreateResultModel> PaymentsAsync(int id, InvoicePaymentsCreateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "payments"]);
            return PostAsync<InvoicePaymentsCreateResultModel>(parameters, model, cancellationToken);
        }

        public Task<IEnumerable<PaymentModel>> PaymentsAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "payments"]);
            return GetAsync<IEnumerable<PaymentModel>>(parameters, cancellationToken);
        }

        public Task<RefundStateModel> RefundStateAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "refund", "state"]);
            return GetAsync<RefundStateModel>(parameters, cancellationToken);
        }
    }
}
