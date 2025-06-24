using System.Net.Http;
using Gizmo.Web.Api.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Stock count web api client.
    /// </summary>
    [WebApiRoute("api/v3/stockcount")]
    public sealed class StockCountWebApiClient : WebApiClientBase
    {
        public StockCountWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
           base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<StockCountModel>> GetAsync(StockCountFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<StockCountModel>>(parameters, ct);
        }

        public Task<StockCountModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<StockCountModel>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(StockCountModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<PagedList<StockCountEntryModel>> GetEntriesAsync(int id, StockCountEntryFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "entries"], filter);
            return GetAsync<PagedList<StockCountEntryModel>>(parameters, ct);
        }
    }
}
