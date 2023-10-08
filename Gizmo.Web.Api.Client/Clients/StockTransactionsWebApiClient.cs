using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/stocktransactions")]
    public sealed class StockTransactionsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public StockTransactionsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

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
        
        #endregion
    }
}
