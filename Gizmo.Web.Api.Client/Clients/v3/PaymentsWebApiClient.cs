using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/payments")]
    public sealed class PaymentsWebApiClient : WebApiClientBase
    {
        public PaymentsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedListClassic<PaymentTransactionModel>> TransactionsAsync(PaymentTransactionFilterClassic filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["transactions"], filter);
            return GetAsync<PagedListClassic<PaymentTransactionModel>>(parameters, cancellationToken);
        }
    }
}
