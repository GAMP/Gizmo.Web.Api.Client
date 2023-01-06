using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/reservations")]
    public class ReservationsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ReservationsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ReservationModel>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<ReservationModel>> GetAsync(ReservationsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ReservationModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ReservationModelCreate reservationModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), reservationModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ReservationModelUpdate reservationModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), reservationModelUpdate, ct);
        }

        public Task<ReservationModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ReservationModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        } 

        #endregion
    }
}
