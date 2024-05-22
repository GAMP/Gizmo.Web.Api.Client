using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/shifts")]
    public sealed class ShiftsWebApiClient : WebApiClientBase
    {
        public ShiftsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<ShiftModel>> GetAsync(ShiftFilterModel filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ShiftModel>>(parameters, cancellationToken);
        }

        public Task<ShiftModel> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ShiftModel>(parameters, cancellationToken);
        }

        public Task<UpdateResult> EndAsync(int id, ShiftEndModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { id, "end" });
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> LockAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { id, "lock" });
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<UpdateResult> UnlockAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { id, "unlock" });
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<ShiftExpectedModel> ExpectedAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { id, "expected" });
            return GetAsync<ShiftExpectedModel>(parameters, cancellationToken);
        }
    }
}
