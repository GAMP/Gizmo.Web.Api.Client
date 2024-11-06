using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/applicationstats")]
    public sealed class ApplicationStatsWebApiClient : WebApiClientBase
    {
        public ApplicationStatsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<AppStatModel>> GetAsync(AppStatsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<AppStatModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(int appExeId, AppStatCreateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["appExe", appExeId]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        } 
    }
}
