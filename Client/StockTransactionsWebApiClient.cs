using Gizmo.Web.Api.Models;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/stocktransactions")]
    public class StockTransactionsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public StockTransactionsWebApiClient(HttpClient httpClient) : base(httpClient)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<StockTransaction>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<StockTransaction>> GetAsync(StockTransactionsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<StockTransaction>>(filter, ct);
        }

        public Task<StockTransaction> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<StockTransaction>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        } 
        
        #endregion
    }
}
