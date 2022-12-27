using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Models.API.Request;
using Gizmo.Web.Api.Models.Models.API.Request.MoneySalePreset;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/salepresets/money")]
    public class MoneySalePresetsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public MoneySalePresetsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<MoneySalePreset>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<MoneySalePreset>> GetAsync(MoneySalePresetsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<MoneySalePreset>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(MoneySalePresetModelCreate moneySalePresetModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), moneySalePresetModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(MoneySalePresetModelUpdate moneySalePresetModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), moneySalePresetModelUpdate, ct);
        }

        public Task<MoneySalePreset> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<MoneySalePreset>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
