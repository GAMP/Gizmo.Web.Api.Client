using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/taxes")]
    public class TaxesWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public TaxesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<TaxModel>> GetAsync(TaxesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<TaxModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(TaxModelCreate taxModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), taxModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(TaxModelUpdate taxModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), taxModelUpdate, ct);
        }

        public Task<TaxModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<TaxModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
