using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/stocktransactions")]
    public sealed class StockTransactionsWebApiClient : WebApiClientBase
    {
        public StockTransactionsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<StockTransactionModel>> GetAsync(StockTransactionsFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<StockTransactionModel>>(parameters, ct);
        }

        public Task<StockTransactionModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<StockTransactionModel>(parameters, ct);
        }

        public async Task<UpdateResult> TransactionAsync(StockTransactionCreateModel model, CancellationToken cancellationToken = default)
        {
            return await PostAsync<UpdateResult>(UriParameters.Empty, model, cancellationToken);
        }
    }
}
