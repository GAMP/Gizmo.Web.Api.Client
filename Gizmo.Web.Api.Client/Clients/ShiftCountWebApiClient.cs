using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/shiftcount")]
    public sealed class ShiftCountWebApiClient : WebApiClientBase
    {
        public ShiftCountWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<ShiftCountModel>> GetAsync(ShiftCountFilter filter, CancellationToken cancellationToken =default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ShiftCountModel>>(parameters, cancellationToken);
        }

        public Task<ShiftCountModel> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ShiftCountModel>(parameters, cancellationToken);
        }
    }
}
