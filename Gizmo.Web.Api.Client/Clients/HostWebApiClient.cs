﻿using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/hosts")]
    public sealed class HostWebApiClient : WebApiClientBase
    {
        public HostWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public async Task<PagedList<HostModel>> GetAsync(HostsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return await GetAsync<PagedList<HostModel>>(parameters, cancellationToken);
        }

        public async Task<CreateResult> CreateAsync(HostModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return await PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public async Task<UpdateResult> UpdateAsync(HostModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return await PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public async Task<HostModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return await GetAsync<HostModel>(parameters, cancellationToken);
        }

        public async Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return await DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public async Task<UpdateResult> UnDeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return await PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public async Task<PagedList<DeviceHostModel>> DeviceHostAssignmentsGetAsync(int id, HostDeviceFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "devices", "assignments"], filter);
            return await GetAsync<PagedList<DeviceHostModel>>(parameters, cancellationToken);
        }

        public async Task<PagedList<DeviceModel>> DeviceHostGetAsync(int id, HostDeviceFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "devices"], filter);
            return await GetAsync<PagedList<DeviceModel>>(parameters, cancellationToken);
        }

        public async Task<CreateResult> HostDeviceAddAsync(int id, int deviceId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "devices", deviceId]);
            return await PostAsync<CreateResult>(parameters, null, cancellationToken);
        }

        public async Task<DeleteResult> HostDeviceRemoveAsync(int id, int deviceId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "devices", deviceId]);
            return await DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }
    }
}
