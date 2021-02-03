using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/stocktransactions")]
    public class StockTransactionsWebApiClient : WebApiClientBase
    {
        public StockTransactionsWebApiClient(HttpClient httpClient) : base(httpClient)
        {
        }

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
    }
}
