using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/hostlayoutgroups")]
    public class HostLayoutGroupsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public HostLayoutGroupsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<HostLayoutGroupModel>> GetAsync(HostLayoutGroupsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<HostLayoutGroupModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(HostLayoutGroupModelCreate hostLayoutGroup, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), hostLayoutGroup, ct);
        }

        public Task<UpdateResult> UpdateAsync(HostLayoutGroupModelUpdate hostLayoutGroup, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), hostLayoutGroup, ct);
        }

        public Task<HostLayoutGroupModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<HostLayoutGroupModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}