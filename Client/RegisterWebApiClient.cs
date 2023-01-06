using Gizmo.Web.Api.Models;

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

        public Task<PagedList<RegisterModel>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<RegisterModel>> GetAsync(RegistersFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<RegisterModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(RegisterModelCreate registerModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), registerModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(RegisterModelUpdate registerModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), registerModelUpdate, ct);
        }

        public Task<RegisterModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<RegisterModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
