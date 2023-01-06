using Gizmo.Web.Api.Models;

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

        public Task<PagedList<MoneySalePresetModel>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<MoneySalePresetModel>> GetAsync(MoneySalePresetsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<MoneySalePresetModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(MoneySalePresetModelCreate moneySalePresetModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), moneySalePresetModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(MoneySalePresetModelUpdate moneySalePresetModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), moneySalePresetModelUpdate, ct);
        }

        public Task<MoneySalePresetModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<MoneySalePresetModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
