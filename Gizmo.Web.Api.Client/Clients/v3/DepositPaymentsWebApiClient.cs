using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/depositpayments")]
    public sealed class DepositPaymentsWebApiClient : WebApiClientBase
    {
        public DepositPaymentsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<DepositPaymentCreateResultModel> CreateAsync(int userId, DepositPaymentCreateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["users", userId]);
            return PostAsync<DepositPaymentCreateResultModel>(parameters, model, cancellationToken);
        }

        public Task<DepositPaymentRefundResultModel> VoidAsync(int id, RefundModel? model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "void"]);
            return PutAsync<DepositPaymentRefundResultModel>(parameters, model, cancellationToken);
        }

        public Task<RefundStateModel> RefundStateAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "refund", "state"]);
            return GetAsync<RefundStateModel>(parameters, cancellationToken);
        }

        public Task<FiscalReceiptStatusResultWaitModel> PaymentReceiptWaitAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "receipt", "wait"]);
            return GetAsync<FiscalReceiptStatusResultWaitModel>(parameters, cancellationToken);
        }

        public Task<FiscalReceiptStatusResultWaitModel> RefundReceiptAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "refund", "receipt", "wait"]);
            return GetAsync<FiscalReceiptStatusResultWaitModel>(parameters, cancellationToken);
        }

        public Task<UpdateResult> WithdrawAsync(int userId, DepositWithdrawModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["users", userId, "withdraw"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DepositWithdrawPaymentsStateModel> WithdrawPaymentsStateAsync(int userId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["users", userId, "withdraw", "payments", "state"]);
            return GetAsync<DepositWithdrawPaymentsStateModel>(parameters, cancellationToken);
        }
    }
}
