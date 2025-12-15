using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/fiscalizations")]
    public sealed class FiscalizationsWebApiClient : WebApiClientBase
    {
        public FiscalizationsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<FiscalizationCreateResultModel> CreateAsync(FiscalizationCreateModel model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<FiscalizationCreateResultModel>(parameters, model, ct);
        }
    }
}
