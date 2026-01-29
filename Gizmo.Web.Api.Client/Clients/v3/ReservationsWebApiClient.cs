using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/reservations")]
    public sealed class ReservationsWebApiClient : WebApiClientBase
    {
        public ReservationsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<ReservationModel>> GetAsync(ReservationsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ReservationModel>>(parameters, cancellationToken);
        }

        public Task<ReservationModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ReservationModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(HostReservationModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(ReservationModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<PagedList<ReservationAvailableHostModel>> AvailabilityAsync(ReservationHostAvailabilityFilterModel filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["availability"], filter);
            return GetAsync<PagedList<ReservationAvailableHostModel>>(parameters, cancellationToken);
        }

        public Task<IEnumerable<ReservationOfferCreateResultModel>> OfferAsync(ReservationOfferCreateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["offer"], model);
            return GetAsync<IEnumerable<ReservationOfferCreateResultModel>>(parameters, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<PagedList<HostNextReservationModel>> HostsNextAsync(HostNextReservationFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["hosts", "next"], filter);
            return GetAsync<PagedList<HostNextReservationModel>>(parameters, cancellationToken);
        }

        public Task<NextHostReservationModel> HostNextAsync(int hostId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["hosts", hostId, "next"]);
            return GetAsync<NextHostReservationModel>(parameters, cancellationToken);
        }

        public Task<UpdateResult> MoveAsync(int id, ReservationHostMoveModel model, CancellationToken cancellationToken)
        {
            var parameters = new UriParameters([id, "hosts", "move"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> CancelAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "cancel"]);
            return PutAsync<UpdateResult>(parameters, cancellationToken);
        }

        public Task<UpdateResult> CompleteAsync(int id, int hostId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "hosts", hostId, "complete"]);
            return PutAsync<UpdateResult>(parameters, cancellationToken);
        }

        public Task<UpdateResult> CompleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "complete"]);
            return PutAsync<UpdateResult>(parameters, cancellationToken);
        }

        public Task<ReservationOrderModel> OrderAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "order"]);
            return GetAsync<ReservationOrderModel>(parameters, cancellationToken);
        }

        public Task<IEnumerable<PaymentModel>> PaymentsAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "payments"]);
            return GetAsync<IEnumerable<PaymentModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> UserAddAsync(int id, ReservationUserModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "users"]);
            return PutAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> UserRemoveAsync(int id, int userId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "users", userId]);
            return PutAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<string?> NoteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "note"]);
            return GetAsync<string?>(parameters, cancellationToken);
        }

        public Task<UpdateResult> NoteAsync(int id, string? note, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "note"]);
            return PutAsync<UpdateResult>(parameters, note, cancellationToken);
        }

        public Task<CreateResult> HostAddAsync(int id, ReservationHostModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "hosts"]);
            return PutAsync<CreateResult>(parameters, model, cancellationToken);
        }
    }
}
