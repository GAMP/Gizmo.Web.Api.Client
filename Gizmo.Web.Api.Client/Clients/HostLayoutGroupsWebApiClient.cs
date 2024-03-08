using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/hostlayoutgroups")]
    public sealed class HostLayoutGroupsWebApiClient : WebApiClientBase
    {
        public HostLayoutGroupsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<HostLayoutGroupModel>> GetAsync(HostLayoutGroupsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<HostLayoutGroupModel>>(parameters, cancellationToken);
        }

        public Task<HostLayoutGroupModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<HostLayoutGroupModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(HostLayoutGroupModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(HostLayoutGroupModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public async Task<HostLayoutGroupLayoutModel> LayoutGetAsync(int id, int hostId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "host", hostId, "layout"]);
            return await GetAsync<HostLayoutGroupLayoutModel>(parameters, cancellationToken);
        }

        public async Task<CreateResult> LayoutSetAsync(int id, int hostId, HostLayoutGroupLayoutModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "host", hostId, "layout"]);
            return await PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public async Task<DeleteResult> LayoutDeleteAsync(int id, int hostId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "host", hostId, "layout"]);
            return await DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public async Task<UpdateResult> LayoutHideAsync(int id, int hostId, bool hide, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "host", hostId, "layout", "hide", hide]);
            return await PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }
    }
}
