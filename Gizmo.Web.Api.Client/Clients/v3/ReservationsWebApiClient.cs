using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

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

        public Task<CreateResult> CreateAsync(ReservationModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(ReservationModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<ReservationModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ReservationModel>(parameters, cancellationToken);
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
    }
}
