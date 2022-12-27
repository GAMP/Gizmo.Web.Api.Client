using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Models.API.Request;
using Gizmo.Web.Api.Models.Models.API.Request.Register;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/registers")]
    public class RegisterWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public RegisterWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<Register>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<Register>> GetAsync(RegistersFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<Register>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(RegisterModelCreate registerModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), registerModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(RegisterModelUpdate registerModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), registerModelUpdate, ct);
        }

        public Task<Register> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<Register>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
