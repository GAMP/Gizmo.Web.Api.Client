using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/userguests")]
    public sealed class UserGuestsWebApiClient : WebApiClientBase
    {
        public UserGuestsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<ReserveGuestResultModel> ReserveAsync(ReservedGuestModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["reserve"]);
            return PostAsync<ReserveGuestResultModel>(parameters,model, cancellationToken);
        }

        public Task<IEnumerable<ReservedGuestReleaseModel>> HostReleaseAsync(int hostId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["host", hostId, "release"]);
            return PostAsync<IEnumerable<ReservedGuestReleaseModel>>(parameters, null, cancellationToken);
        }
    }
}
