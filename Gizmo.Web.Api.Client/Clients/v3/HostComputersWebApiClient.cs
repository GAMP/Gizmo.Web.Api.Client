using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/hostcomputers")]
    public sealed class HostComputersWebApiClient : WebApiClientBase
    {
        public HostComputersWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<ScreenCaptureModel> ScreenGetAsync(int id, ScreenCaptureParametersModel screenCaptureParameters, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "screen"], screenCaptureParameters);
            return GetAsync<ScreenCaptureModel>(parameters, cancellationToken);
        }

        public Task<ScreenCaptureModel> ScreenLastGetAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "screen", "last"]);
            return GetAsync<ScreenCaptureModel>(parameters, cancellationToken);
        }

        public Task<UpdateResult> RebootAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "reboot"]);
            return PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<UpdateResult> ShutdownAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "shutdown"]);
            return PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<UpdateResult> InputLockAsync(int id, bool state, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "input", "lock", state]);
            return PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<bool> InputLockGetAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "input", "lock"]);
            return GetAsync<bool>(parameters, cancellationToken);
        }

        public Task<UpdateResult> MaintenanceAsync(int id, bool state, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "maintenance", state]);
            return PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<bool> MaintenanceGetAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "maintenance"]);
            return GetAsync<bool>(parameters, cancellationToken);
        }

        public Task<UpdateResult> SecurityAsync(int id, bool state, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "security", state]);
            return PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<bool> SecurityGetAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "security"]);
            return GetAsync<bool>(parameters, cancellationToken);
        }

        public Task<UpdateResult> OutOfOrderAsync(int id, bool state, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "outoforder", state]);
            return PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<bool> OutOfOrderGetAsync(int id, bool state, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "outoforder"]);
            return GetAsync<bool>(parameters, cancellationToken);
        }

        public Task<UpdateResult> RestartClientAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "client", "restart"]);
            return PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<PagedList<HostComputerConnectionStateModel>> ConnectionsAsync(HostComputerConnectionStateFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["client", "connections"], filter);
            return GetAsync<PagedList<HostComputerConnectionStateModel>>(parameters, cancellationToken);
        }

        public Task<HostComputerConnectionStateModel> ConnectionAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "client", "connection"]);
            return GetAsync<HostComputerConnectionStateModel>(parameters, cancellationToken);
        }

        public Task<IEnumerable<SystemProcessModel>> ProcessesAsync(int id, SystemProcessFilterModel filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "processes"], filter);
            return GetAsync<IEnumerable<SystemProcessModel>>(parameters, cancellationToken);
        }

        public Task<SystemProcessModel> ProcessAsync(int id, int processId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "processes", processId]);
            return GetAsync<SystemProcessModel>(parameters, cancellationToken);
        }

        public Task<SystemProcessModuleModel> ProcessModuleAsync(int id, int processId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "processes", processId, "module"]);
            return GetAsync<SystemProcessModuleModel>(parameters, cancellationToken);
        }

        public Task<DeleteResult> ProcessTerminateAsync(int id, int processId, TerminateProcessParameters terminateParameters, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "processes", processId], terminateParameters);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<DeleteResult> ProcessTerminateAsync(int id, string processName, TerminateProcessParameters terminateParameters, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "processes", processName], terminateParameters);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<DeleteResult> ProcessTerminateByPathAsync(int id, string executablePath, TerminateProcessParameters terminateParameters, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "processes", "path", executablePath], terminateParameters);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<SystemProcessCreateResultModel> ProcessCreateAsync(int id, SystemProcessCreateModel createParameters, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "processes"]);
            return PostAsync<SystemProcessCreateResultModel>(parameters, createParameters, cancellationToken);
        }

        public Task<double> CpuUsageAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "cpu", "usage"]);
            return GetAsync<double>(parameters, cancellationToken);
        }
    }
}
