using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{    
    [WebApiRoute("api/v2/hostcomputers")]
    public sealed class HostComputersWebApiClient : WebApiClientBase
    {
        public HostComputersWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<ScreenCaptureModel> ScreenGetAsync(int id, ScreenCaptureParametersModel screenCaptureParameters,CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "screen"],screenCaptureParameters);
            return GetAsync<ScreenCaptureModel>(parameters, cancellationToken);
        }

        public Task<ScreenCaptureModel> ScreenLastGetAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "screen", "last"]);
            return GetAsync<ScreenCaptureModel>(parameters, cancellationToken);
        }
    }
}
