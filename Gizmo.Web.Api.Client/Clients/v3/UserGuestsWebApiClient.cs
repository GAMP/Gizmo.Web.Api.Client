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

        public Task<IEnumerable<UserGuestVirtualResult>> VirtualAsync(UserGuestVirtualFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["virtual"],filter);
            return GetAsync<IEnumerable<UserGuestVirtualResult>>(parameters, cancellationToken);
        }

        public Task<ReserveGuestResultModel> ReserveAsync(ReservedGuestModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["reserve"]);
            return PostAsync<ReserveGuestResultModel>(parameters, model, cancellationToken);
        }

        public Task<IEnumerable<ReservedGuestReleaseModel>> HostReleaseAsync(int hostId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["hosts", hostId, "release"]);
            return PostAsync<IEnumerable<ReservedGuestReleaseModel>>(parameters, null, cancellationToken);
        }

        public Task<bool> ReleaseAsync(int userId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([userId, "release"]);
            return PostAsync<bool>(parameters, null, cancellationToken);
        }

        public Task<int> JoinedAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["joined"]);
            return GetAsync<int>(parameters, cancellationToken);
        }
    }
}
