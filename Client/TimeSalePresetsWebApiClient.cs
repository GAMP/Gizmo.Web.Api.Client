using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/salepresets/time")]
    public class TimeSalePresetsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public TimeSalePresetsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<TimeSalePreset>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<TimeSalePreset>> GetAsync(TimeSalePresetsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<TimeSalePreset>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(TimeSalePresetModelCreate timeSalePresetModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), timeSalePresetModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(TimeSalePresetModelUpdate timeSalePresetModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), timeSalePresetModelUpdate, ct);
        }

        public Task<TimeSalePreset> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<TimeSalePreset>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
