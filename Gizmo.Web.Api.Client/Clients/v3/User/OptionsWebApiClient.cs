using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    [UnsecureWebApiClient()]
    [WebApiRoute("api/user/v3/options")]
    public sealed class OptionsWebApiClient : WebApiClientBase
    {
        public OptionsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<MobileOptionsModel> GetMobileAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["mobile"]);
            return GetAsync<MobileOptionsModel>(parameters, cancellationToken);
        }
    }
}
