using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/hosts")]
    public class HostWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public HostWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<Host>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<Host>> GetAsync(HostsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<Host>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(HostModelCreate hostModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), hostModelCreate, ct);
        }
        public Task<UpdateResult> UpdateAsync(HostModelUpdate hostModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), hostModelUpdate, ct);
        }

        public Task<Host> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<Host>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
