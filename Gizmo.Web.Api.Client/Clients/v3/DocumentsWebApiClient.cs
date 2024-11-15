using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

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

        public Task<CreateResult> CreateAsync(DocumentCreateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
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

        public Task<UpdateResult> UnDeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "undelete"]);
            return PutAsync<UpdateResult>(parameters, cancellationToken);
        }

        public Task<ExistResult> FileNameExistsAsync(string fileName, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["file", fileName, "exists"]);
            return GetAsync<ExistResult>(parameters, cancellationToken);
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
}
