using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Models.API.Request;
using Gizmo.Web.Api.Models.Models.API.Request.Transaction.Asset;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/assettransactions")]
    public class AssetTransactionsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public AssetTransactionsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<AssetTransaction>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<AssetTransaction>> GetAsync(AssetTransactionsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<AssetTransaction>>(filter, ct);
        }

        public Task<AssetTransaction> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<AssetTransaction>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}