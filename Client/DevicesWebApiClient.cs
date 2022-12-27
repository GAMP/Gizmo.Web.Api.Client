using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Models.API.Request;
using Gizmo.Web.Api.Models.Models.API.Request.Device.Host;
using Gizmo.Web.Api.Models.Models.API.Request.Device.Model;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/devices")]
    public class DevicesWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public DevicesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region GET

        public Task<PagedList<Device>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        #endregion

        #region GET

        public Task<PagedList<Device>> GetAsync(DevicesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<Device>>(filter, ct);
        }

        #endregion

        #region CREATE

        public Task<CreateResult> CreateAsync(DeviceModelCreate deviceModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), deviceModelCreate, ct);
        }
        
        #endregion

        #region UPDATE

        public Task<UpdateResult> UpdateAsync(DeviceModelUpdate deviceModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), deviceModelUpdate, ct);
        }
        
        #endregion

        #region DELETE

        public Task<DeleteResult> DeleteAsync(int deviceId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{deviceId}"), ct);
        }
        
        #endregion

        #region UNDELETE

        public Task UndeleteAsync(int deviceId, CancellationToken ct = default)
        {
            return PutAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{deviceId}/undelete"), default, ct);
        }
        
        #endregion

        #region ENABLE

        public Task EnableAsync(int deviceId, CancellationToken ct = default)
        {
            return PutAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{deviceId}/enable"), default, ct);
        }
        
        #endregion

        #region DISABLE

        public Task DisableAsync(int deviceId, CancellationToken ct = default)
        {
            return PutAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{deviceId}/disable"), default, ct);
        }
        
        #endregion

        #region DEVICE HOST GET

        public Task<PagedList<DeviceHost>> HostGetAsync(CancellationToken ct = default)
        {
            return HostGetAsync(default, ct);
        }

        #endregion

        #region DEVICE HOST GET

        public Task<PagedList<DeviceHost>> HostGetAsync(DeviceHostFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<DeviceHost>>(CreateRequestUrl("hosts",filter), ct);
        }

        #endregion

        #region HOST ADD

        public Task<CreateResult> HostAddAsync(int deviceId, int hostId, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"{deviceId}/host/{hostId}"),default, ct);
        }

        #endregion

        #region HOST REMOVE

        public Task<DeleteResult> HostRemoveAsync(int deviceId,int hostId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{deviceId}/host/{hostId}"), ct);
        }
        
        #endregion
    }
}
