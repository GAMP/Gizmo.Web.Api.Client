using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
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
            var parameters = new UriParameters(new object[] { "time" });
            return GetAsync<PagedList<TimeSalePresetModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateTimeSalePresetAsync(TimeSalePresetModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "time" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateTimeSalePresetAsync(TimeSalePresetModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "time" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<TimeSalePresetModel> GetTimeSalePresetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "time", id });
            return GetAsync<TimeSalePresetModel>(parameters, ct);
        }

        public Task<DeleteResult> DeleteTimeSalePresetAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "time", id });
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        #endregion

        #region MoneySalePreset

        public Task<PagedList<MoneySalePresetModel>> GetMoneySalePresetsAsync(CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "money" });
            return GetAsync<PagedList<MoneySalePresetModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateMoneySalePresetAsync(MoneySalePresetModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "money" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateMoneySalePresetAsync(MoneySalePresetModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "money" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<MoneySalePresetModel> GetMoneySalePresetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "money", id });
            return GetAsync<MoneySalePresetModel>(parameters, ct);
        }

        public Task<DeleteResult> DeleteMoneySalePresetAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "money", id });
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        #endregion 

        #endregion
    }
}