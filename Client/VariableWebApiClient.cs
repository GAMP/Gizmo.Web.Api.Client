using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/variables")]
    public class VariableWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public VariableWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<VariableModel>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<VariableModel>> GetAsync(VariablesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<VariableModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(VariableModelCreate variableModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), variableModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(VariableModelUpdate variableModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), variableModelUpdate, ct);
        }

        public Task<VariableModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<VariableModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
