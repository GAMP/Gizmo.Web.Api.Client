using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/salepresets")]
    public class SalePresetsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public SalePresetsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        #region TimeSalePresets

        public Task<PagedList<TimeSalePresetModel>> GetTimeSalePresetsAsync(CancellationToken ct = default)
        {
            return GetAsync<PagedList<TimeSalePresetModel>>(CreateRequestUrlWithRouteParameters($"time"), ct);
        }

        public Task<CreateResult> CreateTimeSalePresetAsync(TimeSalePresetModelCreate timeSalePresetModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"time"), timeSalePresetModelCreate, ct);
        }

        public Task<UpdateResult> UpdateTimeSalePresetAsync(TimeSalePresetModelUpdate timeSalePresetModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"time"), timeSalePresetModelUpdate, ct);
        }

        public Task<TimeSalePresetModel> GetTimeSalePresetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<TimeSalePresetModel>(CreateRequestUrlWithRouteParameters($"time/{id}"), ct);
        }

        public Task<DeleteResult> DeleteTimeSalePresetAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"time/{id}"), ct);
        }

        #endregion

        #region MoneySalePreset

        public Task<PagedList<MoneySalePresetModel>> GetMoneySalePresetsAsync(CancellationToken ct = default)
        {
            return GetAsync<PagedList<MoneySalePresetModel>>(CreateRequestUrlWithRouteParameters($"money"), ct);
        }

        public Task<CreateResult> CreateMoneySalePresetAsync(MoneySalePresetModelCreate moneySalePresetModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"money"), moneySalePresetModelCreate, ct);
        }

        public Task<UpdateResult> UpdateMoneySalePresetAsync(MoneySalePresetModelUpdate moneySalePresetModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"money"), moneySalePresetModelUpdate, ct);
        }

        public Task<MoneySalePresetModel> GetMoneySalePresetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<MoneySalePresetModel>(CreateRequestUrlWithRouteParameters($"money/{id}"), ct);
        }

        public Task<DeleteResult> DeleteMoneySalePresetAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"money/{id}"), ct);
        }

        #endregion 

        #endregion
    }
}