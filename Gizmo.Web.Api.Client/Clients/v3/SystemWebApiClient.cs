using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/system")]
    public sealed class SystemWebApiClient : WebApiClientBase
    {
        public SystemWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<IEnumerable<TimeZoneInfoModel>> TimeZonesAsync()
        {
            var parameters = new UriParameters(["timezones"]);
            return GetAsync<IEnumerable<TimeZoneInfoModel>>(parameters, default);
        }
    }
}
