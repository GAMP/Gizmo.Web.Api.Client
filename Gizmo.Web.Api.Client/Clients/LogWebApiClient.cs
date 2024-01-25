using System.Net.Http;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Threading;

namespace Gizmo.Web.Api.Client.Clients
{
    [WebApiRoute("api/v2/log")]
    public sealed class LogWebApiClient : WebApiClientBase
    {
        public LogWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<LogModel>> GetAsync(LogsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<LogModel>>(parameters, cancellationToken);
        }

        public Task<LogModel> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<LogModel>(parameters, cancellationToken);
        }

        public Task<LogExceptionModel> ExceptionAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { id, "exception" });
            return GetAsync<LogExceptionModel>(parameters, cancellationToken);
        }

        public Task<UpdateResult> ClearAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "clear" });
            return PostAsync<UpdateResult>(parameters, cancellationToken);
        }
    }   
}
