using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/monetaryunits")]
    public class MonetaryUnitsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public MonetaryUnitsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<MonetaryUnitModel>> GetAsync(MonetaryUnitsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<MonetaryUnitModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(MonetaryUnitModelCreate monetaryUnitModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), monetaryUnitModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(MonetaryUnitModelUpdate monetaryUnitModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), monetaryUnitModelUpdate, ct);
        }

        public Task<MonetaryUnitModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<MonetaryUnitModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
