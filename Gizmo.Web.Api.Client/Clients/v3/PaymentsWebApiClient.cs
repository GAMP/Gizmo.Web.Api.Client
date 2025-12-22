using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/payments")]
    public sealed class PaymentsWebApiClient : WebApiClientBase
    {
        public PaymentsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedListClassic<PaymentTransactionModel>> TransactionsAsync(PaymentTransactionFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["transactions"], filter);
            return GetAsync<PagedListClassic<PaymentTransactionModel>>(parameters, cancellationToken);
        }

        public Task<PaymentTransactionsStatsModel> TransactionsStatsAsync(PaymentTransactionStatsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["transactions", "stats"], filter);
            return GetAsync<PaymentTransactionsStatsModel>(parameters, cancellationToken);
        }

        public Task<PaymentReversalResultModel> ReverseAsync(int id, PaymentReversalModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "reverse"]);
            return PostAsync<PaymentReversalResultModel>(parameters, model, cancellationToken);
        }
    }
}
