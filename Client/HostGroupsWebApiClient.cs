using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/hostgroups")]
    public class HostGroupsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public HostGroupsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<HostGroupModel>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<HostGroupModel>> GetAsync(HostGroupsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<HostGroupModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(HostGroupModelCreate hostGroup, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), hostGroup, ct);
        }

        public Task<UpdateResult> UpdateAsync(HostGroupModelUpdate hostGroup, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), hostGroup, ct);
        }
        public Task<HostGroupModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<HostGroupModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        } 

        #endregion
    }
}
