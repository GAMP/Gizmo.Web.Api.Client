#nullable enable

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/files")]
    public sealed class FilesWebApiClient : WebApiClientBase
    {
        public FilesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<FileModel>> GetAsync(FileFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<FileModel>>(parameters, cancellationToken);
        }

        public Task<FileModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<FileModel>(parameters, cancellationToken);
        }

        public async Task<FileCreateResultModel> CreateAsync(FileCreateModel model, Stream stream, IProgress<UploadProgress>? progress = null, string contentType = "application/octet-stream", CancellationToken cancellationToken = default)
        {
            using var content = new MultipartFormDataContent();
            {
                using (var streamHttpContent = new StreamContent(stream))
                {
                    streamHttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);

                    using (HttpContent effectiveContent = progress != null ? new ProgressHttpContent(streamHttpContent, progress) : streamHttpContent)
                    {
                        content.Add(effectiveContent, "file", model.FileName);
                        var parameters = new UriParameters(model);
                        return await PostAsync<FileCreateResultModel>(parameters, content, cancellationToken);
                    }
                }
            }
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<DeleteResult> HardDeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "hard"]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<long> DeletedSizeAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["deleted", "size"]);
            return GetAsync<long>(parameters, cancellationToken);
        }

        public Task<long> DeletedCountAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["deleted", "count"]);
            return GetAsync<long>(parameters, cancellationToken);
        }

        public Task<DeleteResult> PurgeAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["purge"]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }
    }
}
