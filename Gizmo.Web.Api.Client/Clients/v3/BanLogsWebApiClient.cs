using System.Net.Http;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Threading;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/banlogs")]
    public sealed class BanLogsWebApiClient : WebApiClientBase
    {
        public BanLogsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<BanLogModel>> GetAsync(BanLogsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<BanLogModel>>(parameters, cancellationToken);
        }

        public Task<BanLogModel> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<BanLogModel>(parameters, cancellationToken);
        }
    }   
}
