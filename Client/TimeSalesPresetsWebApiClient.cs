using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/timesalepresets")]
    public class TimeSalesPresetsWebApiClient:WebApiClientBase
    {
        #region CONSTRUCTOR
        public TimeSalesPresetsWebApiClient(HttpClient client):base(client)
        {

        }
        #endregion
        #region TimeSalePresetWithTime
        public Task<PagedList<TimeSalePresetWithTime>> GetTimeSalesPresetTimeAsync(CancellationToken ct = default)
        {
            return GetAsync<PagedList<TimeSalePresetWithTime>>(CreateRequestUrlWithRouteParameters($"time"), ct);
        }

        public Task<CreateResult> CreateTimeSalesPresetTimeAsync(TimeSalePresetWithTimeModelCreate timeSalePresetWithTimeModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"time"), ct);
        }

        public Task<UpdateResult> UpdateTimeSalesPresetTimeAsync(TimeSalePresetWithTimeModelUpdate timeSalePresetWithMoneyModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"time"), ct);
        }

        public Task<TimeSalePresetWithTime> GetTimeSalePresetWithTimeByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<TimeSalePresetWithTime>(CreateRequestUrlWithRouteParameters($"time/{id}"), ct);
        }

        public Task<DeleteResult> DeleteTimeSalesPresetTimeAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"time/{id}"), ct);
        }
        #endregion
        #region TImeSalePresetWithMoney
        public Task<PagedList<TimeSalePresetWithMoney>> GetTimeSalesPresetMoneyAsync(CancellationToken ct = default)
        {
            return GetAsync<PagedList<TimeSalePresetWithMoney>>(CreateRequestUrlWithRouteParameters($"money"), ct);
        }

        public Task<CreateResult> CreateTimeSalesPresetMoneyAsync(TimeSalePresetWithMoneyModelCreate timeSalePresetWithTimeModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"money"), ct);
        }

        public Task<UpdateResult> UpdateTimeSalesPresetMoneyAsync(TimeSalePresetWithMoneyModelUpdate timeSalePresetWithMoneyModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"money"), ct);
        }

        public Task<TimeSalePresetWithMoney> GetTimeSalePresetWithMoneyByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<TimeSalePresetWithMoney>(CreateRequestUrlWithRouteParameters($"money/{id}"), ct);
        }

        public Task<DeleteResult> DeleteTimeSalesPresetMoneyAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"money/{id}"), ct);
        }
        #endregion
    }
}
