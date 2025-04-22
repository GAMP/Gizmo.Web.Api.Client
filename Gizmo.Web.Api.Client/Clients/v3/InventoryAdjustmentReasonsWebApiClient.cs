using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/inventoryadjustmentreasons")]
    public sealed class InventoryAdjustmentReasonsWebApiClient : WebApiClientBase
    {
        public InventoryAdjustmentReasonsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<InventoryAdjustmentModel>> GetAsync(InventoryAdjustmentReasonFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<InventoryAdjustmentModel>>(parameters, cancellationToken);
        }

        public Task<InventoryAdjustmentModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<InventoryAdjustmentModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(InventoryAdjustmentModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(InventoryAdjustmentReasonModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<DeleteResult> UnDeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "undelete"]);
            return PutAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<ExistResult> NameExistAsync(string name, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["name", name, "exists"]);
            return GetAsync<ExistResult>(parameters, cancellationToken);
        }
    }
}
