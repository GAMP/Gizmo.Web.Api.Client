using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/reservations")]
    public class ReservationsWebApiClient : WebApiClientBase
    {
        public ReservationsWebApiClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<PagedList<Reservation>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<Reservation>> GetAsync(ReservationsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<Reservation>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ReservationModelCreate reservationModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), reservationModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ReservationModelUpdate reservationModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), reservationModelUpdate, ct);
        }

        public Task<Reservation> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<Reservation>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

    }

}
