using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/assettransactions")]
    public sealed class AssetTransactionsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public AssetTransactionsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<AssetTransactionModel>> GetAsync(AssetTransactionsFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<AssetTransactionModel>>(parameters, ct);
        }

        public Task<AssetTransactionModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<AssetTransactionModel>(parameters, ct);
        }

        #endregion
    }
}
