using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/notifications")]
    public sealed class NotificationsWebApiClient : WebApiClientBase
    {
        public NotificationsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<NotificationModel>> GetAsync(NotificationsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<NotificationModel>>(parameters, cancellationToken);
        }

        public Task<NotificationModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<NotificationModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(NotificationTimedRemainingModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["timed", "remaining"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(NotificationTimedRemainingModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["timed", "remaining"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(NotificationTimedReservationModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["timed", "reservation"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(NotificationTimedReservationModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["timed", "reservation"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> EnableAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "enable"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<UpdateResult> DisableAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "disable"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }
    }
}
