using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    /// <summary>
    /// Reservations api client, user surface — the reservations of the authenticated user.
    /// </summary>
    [WebApiRoute("api/user/v3/reservations")]
    public sealed class ReservationsWebApiClient : WebApiClientBase
    {
        public ReservationsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        /// <summary>
        /// Gets the current / upcoming or the completed reservations of the user, depending on the filter mode.
        /// </summary>
        public Task<PagedList<UserReservationModel>> GetAsync(UserReservationsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<UserReservationModel>>(parameters, cancellationToken);
        }

        /// <summary>
        /// Cancels a not started reservation owned by the user.
        /// </summary>
        public Task<UpdateResult> CancelAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["cancel", id]);
            return PutAsync<UpdateResult>(parameters, cancellationToken);
        }
    }
}
