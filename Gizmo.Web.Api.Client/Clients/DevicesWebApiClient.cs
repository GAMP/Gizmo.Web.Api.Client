using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/devices")]
    public sealed class DevicesWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public DevicesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region GET

        public Task<PagedList<DeviceModel>> GetAsync(DevicesFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<DeviceModel>>(parameters, ct);
        }

        #endregion

        #region CREATE

        public Task<CreateResult> CreateAsync(DeviceModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }
        
        #endregion

        #region UPDATE

        public Task<UpdateResult> UpdateAsync(DeviceModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }
        
        #endregion

        #region DELETE

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }
        
        #endregion

        #region UNDELETE

        public Task UndeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] {id, "undelete" });
            return PutAsync<DeleteResult>(parameters, null, ct);
        }
        
        #endregion

        #region ENABLE

        public Task EnableAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "enable" });
            return PutAsync<DeleteResult>(parameters, null, ct);
        }
        
        #endregion

        #region DISABLE

        public Task DisableAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "disable" });
            return PutAsync<DeleteResult>(parameters, null, ct);
        }
        
        #endregion


        #region DEVICE HOST GET

        public Task<PagedList<DeviceHostModel>> HostGetAsync(DeviceHostFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "hosts" }, filter);
            return GetAsync<PagedList<DeviceHostModel>>(parameters, ct);
        }

        #endregion

        #region HOST ADD

        public Task<CreateResult> HostAddAsync(int deviceId, int hostId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { deviceId, "host", hostId });
            return PostAsync<CreateResult>(parameters, null, ct);
        }

        #endregion

        #region HOST REMOVE

        public Task<DeleteResult> HostRemoveAsync(int deviceId,int hostId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { deviceId, "host", hostId });
            return DeleteAsync<DeleteResult>(parameters, ct);
        }
        
        #endregion
    }
}
