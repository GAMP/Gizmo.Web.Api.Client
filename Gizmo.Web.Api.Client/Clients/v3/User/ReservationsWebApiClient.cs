using System.Collections.Generic;
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

        /// <summary>
        /// Gets the reservation options the booking flow depends on (duration bounds, fee, minimum payment).
        /// </summary>
        public Task<UserReservationOptionsModel> OptionsAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["options"]);
            return GetAsync<UserReservationOptionsModel>(parameters, cancellationToken);
        }

        /// <summary>
        /// Gets the halls of the branch with the host layout, the bookable hosts and their host groups.
        /// </summary>
        public Task<UserReservationHallsModel> HallsAsync(int branchId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["halls"], new Dictionary<string, string> { ["branchId"] = branchId.ToString() });
            return GetAsync<UserReservationHallsModel>(parameters, cancellationToken);
        }

        /// <summary>
        /// Gets which hosts of the branch are free for the period.
        /// </summary>
        public Task<IEnumerable<UserReservationHostAvailabilityModel>> AvailabilityAsync(UserReservationPeriodFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["availability"], filter);
            return GetAsync<IEnumerable<UserReservationHostAvailabilityModel>>(parameters, cancellationToken);
        }

        /// <summary>
        /// Gets the session price and the reference hourly rate of every bookable host group for the period.
        /// </summary>
        public Task<IEnumerable<UserReservationHostGroupPriceModel>> PricesAsync(UserReservationPeriodFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["prices"], filter);
            return GetAsync<IEnumerable<UserReservationHostGroupPriceModel>>(parameters, cancellationToken);
        }

        /// <summary>
        /// Creates the offer (cost, fee, minimum payment) for the chosen hosts and period.
        /// </summary>
        public Task<UserReservationOfferResultModel> OfferAsync(UserReservationOfferCreateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["offer"]);
            return PostAsync<UserReservationOfferResultModel>(parameters, model, cancellationToken);
        }

        /// <summary>
        /// Books the offer: pays the amount from the user deposit and creates the reservation.
        /// </summary>
        public Task<UserReservationBookResultModel> BookAsync(UserReservationBookModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["book"]);
            return PostAsync<UserReservationBookResultModel>(parameters, model, cancellationToken);
        }

        /// <summary>
        /// Starts the online payment of the whole outstanding amount of an own not paid reservation; returns the payment page url.
        /// </summary>
        public Task<UserReservationPayResultModel> PayAsync(UserReservationPayModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["pay"]);
            return PostAsync<UserReservationPayResultModel>(parameters, model, cancellationToken);
        }

        /// <summary>
        /// Gets the state of an own reservation payment; an abandoned payment is cancelled by the server.
        /// </summary>
        public Task<UserPaymentIntentStateModel> PaymentStateAsync(UserPaymentIntentFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["payment", "state"], filter);
            return GetAsync<UserPaymentIntentStateModel>(parameters, cancellationToken);
        }
    }
}
