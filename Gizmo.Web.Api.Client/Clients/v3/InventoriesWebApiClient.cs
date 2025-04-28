using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/inventories")]
    public sealed class InventoriesWebApiClient : WebApiClientBase
    {
        public InventoriesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<InventoryModel>> GetAsync(InventoryFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<InventoryModel>>(parameters, cancellationToken);
        }

        public Task<PagedList<InventoryEntryModel>> EntriesAsync(int id, InventoryEntryFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id], filter);
            return GetAsync<PagedList<InventoryEntryModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(InventoryInboundModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["inbound"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(InventoryAdjustmentModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["adjustment"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(InventoryTransferModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["transfer"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(int id, InventoryTransferInboundModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["transfer", id, "inbound"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }
    }
}
