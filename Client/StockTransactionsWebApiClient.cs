using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/stocktransactions")]
    public class StockTransactionsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public StockTransactionsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<StockTransactionModel>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<StockTransactionModel>> GetAsync(StockTransactionsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<StockTransactionModel>>(filter, ct);
        }

        public Task<StockTransactionModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<StockTransactionModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        } 
        
        #endregion
    }
}
