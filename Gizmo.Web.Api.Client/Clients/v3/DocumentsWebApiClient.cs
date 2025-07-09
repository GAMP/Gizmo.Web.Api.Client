#nullable enable

using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.IO;
using System.Net;
using System;
using System.Buffers;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/documents")]
    public sealed class DocumentsWebApiClient : WebApiClientBase
    {
        public DocumentsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<DocumentModel>> GetAsync(DocumentFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<DocumentModel>>(parameters, cancellationToken);
        }

        public Task<DocumentModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<DocumentModel>(parameters, cancellationToken);
        }

        public async Task<FileCreateResultModel> CreateAsync(DocumentCreateModel model, Stream stream, IProgress<UploadProgress>? progress = null, string contentType = "application/octet-stream", CancellationToken cancellationToken = default)
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

        public Task<UpdateResult> UpdateAsync(DocumentUpdateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UndeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "undelete"]);
            return PutAsync<UpdateResult>(parameters, cancellationToken, cancellationToken);
        }

        public Task<bool> FileNameExistsAsync(string fileName, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["file", fileName, "exists"]);
            return GetAsync<bool>(parameters, cancellationToken);
        }

        public Task<UpdateResult> DescriptionAsync(int id, string? description, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "description"]);
            return PutAsync<UpdateResult>(parameters, description, cancellationToken);
        }

        public Task<string?> DescriptionAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "description"]);
            return GetAsync<string?>(parameters, cancellationToken);
        }
    }

    public class ProgressHttpContent : HttpContent
    {
        private readonly int _chunkSize;
        private readonly HttpContent _originalContent;
        private readonly IProgress<UploadProgress>? _progressCallback;

        public ProgressHttpContent(HttpContent originalContent, IProgress<UploadProgress>? progressCallback = null, int chunkSize = 65536)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(chunkSize, 8192, nameof(chunkSize));

            _originalContent = originalContent ?? throw new ArgumentNullException(nameof(originalContent));
            _progressCallback = progressCallback;
            _chunkSize = chunkSize;

            foreach (var header in _originalContent.Headers)
                Headers.Add(header.Key, header.Value);            
        }

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context, CancellationToken cancellationToken)
        {
            var buffer = ArrayPool<byte>.Shared.Rent(_chunkSize);

            try
            {
                long totalBytes = _originalContent.Headers.ContentLength ?? -1;
                long uploadedBytes = 0;

                using (var originalStream = await _originalContent.ReadAsStreamAsync(cancellationToken))
                {
                    int bytesRead;
                    while ((bytesRead = await originalStream.ReadAsync(buffer, cancellationToken)) > 0)
                    {
                        await stream.WriteAsync(buffer.AsMemory(0, bytesRead), cancellationToken);
                        uploadedBytes += bytesRead;

                        _progressCallback?.Report(new UploadProgress() { Total = totalBytes, UploadedTotal = uploadedBytes });
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
        {
            await base.SerializeToStreamAsync(stream, context, default);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = _originalContent.Headers.ContentLength ?? -1;
            return length >= 0;
        }
    }

    public sealed class UploadProgress
    {
        public long Total { get; init; }
        public long UploadedTotal { get; init; }
    }
}
