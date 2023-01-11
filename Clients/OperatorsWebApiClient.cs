using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/operators")]
    public class OperatorsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public OperatorsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<OperatorModel>> GetAsync(OperatorsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<OperatorModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(OperatorModelCreate operatorModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), operatorModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(OperatorModelUpdate operatorModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), operatorModelUpdate, ct);
        }

        public Task<OperatorModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<OperatorModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
