using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
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

        public Task<PagedList<InvoiceReceiptModel>> ReceiptsAsync(InvoiceReceiptsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["receipts"], filter);
            return GetAsync<PagedList<InvoiceReceiptModel>>(parameters, cancellationToken);
        }

        public Task<InvoiceModel> GetByIdAsync(int id, ModelFilterOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { id }, options);
            return GetAsync<InvoiceModel>(parameters, cancellationToken);
        }

        public Task<InvoiceRefundCreateResultModel> VoidAsync(int id, RefundModel? model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "void"]);
            return PutAsync<InvoiceRefundCreateResultModel>(parameters, model, cancellationToken);
        }

        public Task<decimal> LineQuantityAsync(int invoiceLineId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["lines", invoiceLineId, "quantity"]);
            return GetAsync<decimal>(parameters, cancellationToken);
        }

        public Task<UsageSessionActiveInvoiceResultModel> UsageSessionActiveInvoiceAsync(int userId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["users", userId, "usagesession", "active", "invoice"]);
            return PostAsync<UsageSessionActiveInvoiceResultModel>(parameters, null, cancellationToken);
        }

        public Task<CloseBalanceResultModel> CloseBalanceAsync(CloseBalanceCreateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["balance", "close"]);
            return PostAsync<CloseBalanceResultModel>(parameters, model, cancellationToken);
        }

        public Task<CloseBalancePaymentsStateResultModel> CloseBalanceAsync(CloseBalancePaymentsStateCreateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["balance", "close", "payments", "state"]);
            return PostAsync<CloseBalancePaymentsStateResultModel>(parameters, model, cancellationToken);
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

        public Task<FiscalReceiptStatusResultWaitModel> SaleReceiptWaitAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "sale", "receipt", "wait"]);
            return GetAsync<FiscalReceiptStatusResultWaitModel>(parameters, cancellationToken);
        }

        public Task<FiscalReceiptStatusResultWaitModel> ReturnReceiptWaitAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "refund", "receipt", "wait"]);
            return GetAsync<FiscalReceiptStatusResultWaitModel>(parameters, cancellationToken);
        }
    }
}
