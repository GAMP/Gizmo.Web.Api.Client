using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/assistancerequesttypes")]
    public sealed class AssistanceRequestTypesWebApiClient : WebApiClientBase
    {
        public AssistanceRequestTypesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<AssistanceRequestTypeModel>> GetAsync(AssistanceRequestTypeFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<AssistanceRequestTypeModel>>(parameters, cancellationToken);
        }

        public Task<AssistanceRequestTypeModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<AssistanceRequestTypeModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(AssetModelCreate assetModelCreate, CancellationToken cancellationToken = default)
        {
            return PostAsync<CreateResult>(UriParameters.Empty, assetModelCreate, cancellationToken);
        }

        public Task<CreateResult> UpdateAsync(AssetModelCreate assetModelCreate, CancellationToken cancellationToken = default)
        {
            return PutAsync<CreateResult>(UriParameters.Empty, assetModelCreate, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<DeleteResult> UnDeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "undelete"]);
            return PostAsync<DeleteResult>(parameters, cancellationToken);
        }
    }
}
