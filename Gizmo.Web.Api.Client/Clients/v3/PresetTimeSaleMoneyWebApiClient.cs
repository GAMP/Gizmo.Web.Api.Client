using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/presettimesalemoney")]
    public sealed class PresetTimeSaleMoneyWebApiClient : WebApiClientBase
    {
        public PresetTimeSaleMoneyWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<PresetTimeSaleMoneyModel>> GetAsync(PresetTimeSaleMoneyFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<PresetTimeSaleMoneyModel>>(parameters, cancellationToken);
        }

        public Task<PresetTimeSaleMoneyModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<PresetTimeSaleMoneyModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(PresetTimeSaleMoneyModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }
    }
}
