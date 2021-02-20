using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/hosticons")]
    public class HostIconWebApiClient:WebApiClientBase
    {
        #region COSTRUCTOR
        public HostIconWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<HostIcon>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<HostIcon>> GetAsync(HostIconsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<HostIcon>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(HostIconModelCreate hostIconModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), hostIconModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(HostIconModelUpdate hostIconModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), hostIconModelUpdate, ct);
        }

        public Task<HostIcon> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<HostIcon>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        } 

        #endregion
    }
}
