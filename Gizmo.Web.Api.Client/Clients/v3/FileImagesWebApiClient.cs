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
    [WebApiRoute("api/v3/fileimages")]
    public sealed class FileImagesWebApiClient : WebApiClientBase
    {
        public FileImagesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<FileImageModel>> GetAsync(FileImageFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<FileImageModel>>(parameters, cancellationToken);
        }

        public Task<FileImageModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<FileImageModel>(parameters, cancellationToken);
        }

        public async Task<FileCreateResultModel> CreateAsync(FileImageCreateModel model, Stream stream, IProgress<UploadProgress>? progress = null, string contentType = "application/octet-stream", CancellationToken cancellationToken = default)
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

        public Task<UpdateResult> UpdateAsync(FileImageUpdateModel model, CancellationToken cancellationToken = default)
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
            var parameters = new UriParameters(["files", fileName, "exists"]);
            return GetAsync<bool>(parameters, cancellationToken);
        }
    }
}
