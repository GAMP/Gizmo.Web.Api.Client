using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/devices")]
    public sealed class DevicesWebApiClient : WebApiClientBase
    {
        public DevicesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<DeviceModel>> GetAsync(DevicesFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<DeviceModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(DeviceModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(DeviceModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task EnableAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "enable"]);
            return PutAsync<DeleteResult>(parameters, null, cancellationToken);
        }

        public Task DisableAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "disable"]);
            return PutAsync<DeleteResult>(parameters, null, ct);
        }

        public Task<PagedList<DeviceHostModel>> DeviceHostGetAsync(DeviceHostFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["hosts"], filter);
            return GetAsync<PagedList<DeviceHostModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> DeviceHostAddAsync(int deviceId, int hostId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([deviceId, "host", hostId]);
            return PostAsync<CreateResult>(parameters, null, cancellationToken);
        }

        public Task<DeleteResult> DeviceHostRemoveAsync(int deviceId, int hostId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([deviceId, "host", hostId]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<DeviceModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<DeviceModel>(parameters, ct);
        }
    }
}
