using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/shift")]
    public sealed class ShiftWebApiClient : WebApiClientBase
    {
        public ShiftWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<ShiftModel>> GetAsync(ShiftFilterModel filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ShiftModel>>(parameters, ct);
        }

        public Task<ShiftModel> GetAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ShiftModel>(parameters, ct);
        }

        public Task<ShiftModel> StartAsync(ShiftStartModel model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new[] {"start"} );
            return PostAsync<ShiftModel>(parameters,model, ct);
        }

        public Task<ShiftModel> StartAsync(int operatorId ,ShiftStartModel model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { operatorId, "start" });
            return PostAsync<ShiftModel>(parameters, model, ct);
        }

        public Task<UpdateResult> EndAsync(int id, ShiftEndModel model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "end" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<ActiveShiftModel> ActiveAsync(CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "active" });
            return GetAsync<ActiveShiftModel>(parameters, ct);
        }

        public Task<UpdateResult> ActiveEndAsync(ShiftEndModel model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "active", "end" });
            return PostAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> LockAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "lock" });
            return PutAsync<UpdateResult>(parameters, null, ct);
        }

        public Task<UpdateResult> UnlockAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "unlock" });
            return PutAsync<UpdateResult>(parameters, null, ct);
        }

        public Task<UpdateResult> ActiveLockAsync(CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "active", "lock" });
            return PutAsync<UpdateResult>(parameters, null, ct);
        }

        public Task<UpdateResult> ActiveUnlockAsync(CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "active", "unlock" });
            return PutAsync<UpdateResult>(parameters, null, ct);
        }
    }
}
