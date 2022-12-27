using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Models.API.Request;
using Gizmo.Web.Api.Models.Models.API.Request.Operator;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
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

        public Task<PagedList<Operator>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<Operator>> GetAsync(OperatorsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<Operator>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(OperatorModelCreate operatorModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), operatorModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(OperatorModelUpdate operatorModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), operatorModelUpdate, ct);
        }

        public Task<Operator> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<Operator>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
