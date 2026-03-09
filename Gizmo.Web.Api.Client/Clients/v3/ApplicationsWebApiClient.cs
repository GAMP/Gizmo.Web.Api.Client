using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/applications")]
    public sealed class ApplicationsWebApiClient : WebApiClientBase
    {
        public ApplicationsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<ApplicationModel>> GetAsync(ApplicationsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ApplicationModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(ApplicationModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<ApplicationModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ApplicationModel>(parameters, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<ApplicationModelImage> GetApplicationImage(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "images"]);
            return GetAsync<ApplicationModelImage>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UpdateApplicationImage(int id, ApplicationModelImage model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "images"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<CreateResult> Duplicate(int id, ApplicationModelDuplicate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "duplicate"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }
    }
}
