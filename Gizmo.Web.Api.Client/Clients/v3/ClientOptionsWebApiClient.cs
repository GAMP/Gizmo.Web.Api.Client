using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Enumerations;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/clientoptions")]
    public sealed class ClientOptionsWebApiClient : WebApiClientBase
    {
        public ClientOptionsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<ClientOptionModel>> GetAsync(ClientOptionsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ClientOptionModel>>(parameters, cancellationToken);
        }

        public Task<ClientOptionModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ClientOptionModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(ClientOptionModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(ClientOptionModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<ClientOptionSkinImageModel> GetImageAsync(int id, SkinImageType skinImageType, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "image", (int)skinImageType]);
            return GetAsync<ClientOptionSkinImageModel>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UpdateImageAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "image"]);
            return PutAsync<UpdateResult>(parameters, cancellationToken);
        }
    }
}
