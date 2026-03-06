using System.Collections.Generic;
using System.IO;
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

        public Task<SystemProcessCreateResultModel> BatchScriptExecuteAsync(int id, SystemScripProcessCreateModel createParameters, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "script", "batch"]);
            return PostAsync<SystemProcessCreateResultModel>(parameters, createParameters, cancellationToken);
        }

        public Task<SystemProcessCreateResultModel> AutoItScriptExecuteAsync(int id, SystemScripProcessCreateModel createParameters, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "script", "autoit"]);
            return PostAsync<SystemProcessCreateResultModel>(parameters, createParameters, cancellationToken);
        }

        public Task<SystemProcessCreateResultModel> VisualBasicScriptExecuteAsync(int id, SystemScripProcessCreateModel createParameters, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "script", "visualbasic"]);
            return PostAsync<SystemProcessCreateResultModel>(parameters, createParameters, cancellationToken);
        }

        public Task<UpdateResult> RegistryImportAsync(int id, SystemRegistryImportModel createParameters, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "registry", "import"]);
            return PostAsync<UpdateResult>(parameters, createParameters, cancellationToken);
        }

        public Task<UpdateResult> AlertNotificationAsync(int id, SystemAlertNotificationCreateModel createParameters, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "notifications", "alert"]);
            return PostAsync<UpdateResult>(parameters, createParameters, cancellationToken);
        }

        public Task<UpdateResult> JunctionCreateAsync(int id, SystemJunctionCreateModel createParameters, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "junction"]);
            return PostAsync<UpdateResult>(parameters, createParameters, cancellationToken);
        }

        #region FileSystem

        public Task<IEnumerable<FileSystemMountPoint>> FileSystemGetDrivesAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "fs", "drives"]);
            return GetAsync<IEnumerable<FileSystemMountPoint>>(parameters, cancellationToken);
        }

        public IAsyncEnumerable<FileInfoModel> FileSystemStreamDirectoryAsync(int id, DirectoryEnumerateParametersModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "fs", "directory", "stream"], model);
            return GetSseStreamAsync<FileInfoModel>(parameters, cancellationToken);
        }

        public Task<FileInfoModel> FileSystemGetInfoAsync(int id, string path, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "fs", "info"], new PathQueryModel { Path = path });
            return GetAsync<FileInfoModel>(parameters, cancellationToken);
        }

        public Task<bool> FileSystemExistsAsync(int id, string path, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "fs", "exists"], new PathQueryModel { Path = path });
            return GetAsync<bool>(parameters, cancellationToken);
        }

        public Task FileSystemCreateDirectoryAsync(int id, string path, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "fs", "directory"], new PathQueryModel { Path = path });
            return PostAsync<object>(parameters, null, cancellationToken);
        }

        public Task<FileSystemResultModel> FileSystemDeleteAsync(int id, string path, bool recursive, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "fs", "entry"], new FileSystemDeleteQueryModel { Path = path, Recursive = recursive });
            return DeleteAsync<FileSystemResultModel>(parameters, cancellationToken);
        }

        public Task<FileSystemResultModel> FileSystemMoveAsync(int id, FileSystemMoveModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "fs", "move"]);
            return PostAsync<FileSystemResultModel>(parameters, model, cancellationToken);
        }

        public Task FileSystemReadAsync(int id, FileSystemOpenModel model, Stream destination, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "fs", "file"], model);
            return GetContentCopyAsync(parameters, destination, cancellationToken);
        }

        public Task<(HttpResponseMessage Response, Stream Stream, long Length)> FileSystemOpenAsync(int id, FileSystemOpenModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "fs", "file"], model);
            return GetContentStreamAsync(parameters, cancellationToken);
        }

        public Task FileSystemWriteAsync(int id, FileSystemOpenModel model, Stream content, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "fs", "file"], model);
            return PutContentCopyAsync(parameters, content, cancellationToken);
        }

        public Task<FileSystemResultModel> FileSystemSetAttributesAsync(int id, string path, FileAttributes attributes, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "fs", "attributes"], new FileSystemSetAttributesQueryModel { Path = path, Attributes = attributes });
            return PatchAsync<FileSystemResultModel>(parameters, cancellationToken);
        }

        public Task<FileSystemResultModel> FileSystemSetLengthAsync(int id, string path, long length, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "fs", "length"], new FileSystemSetLengthQueryModel { Path = path, Length = length });
            return PatchAsync<FileSystemResultModel>(parameters, cancellationToken);
        }

        public Task<FileSystemResultModel> FileSystemSetTimestampsAsync(int id, FileSystemSetTimestampsModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "fs", "timestamps"]);
            return PatchAsync<FileSystemResultModel>(parameters, model, cancellationToken);
        }

        public Task FileSystemDownloadBatchAsync(int id, FileSystemDownloadBatchModel model, Stream destination, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "fs", "download", "batch"]);
            return PostContentCopyAsync(parameters, model, destination, cancellationToken);
        }

        #endregion
    }
}
