using System.Net.Http;
using Gizmo.Web.Api.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/assistancerequest")]
    public sealed class AssistanceRequestsWebApiClient : WebApiClientBase
    {
        public AssistanceRequestsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<AssistanceRequestModel>> GetAsync(AssistanceRequestFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<AssistanceRequestModel>>(parameters, cancellationToken);
        }

        public Task<AssistanceRequestModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id]);
            return GetAsync<AssistanceRequestModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(AssistanceRequestModelCreate createModel, CancellationToken cancellationToken = default)
        {
            return PostAsync<CreateResult>(UriParameters.Empty, createModel, cancellationToken);
        }

        public Task<AssistanceRequestModel> AcceptAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "accept"]);
            return PutAsync<AssistanceRequestModel>(parameters, null, cancellationToken);
        }

        public Task<AssistanceRequestModel> RejectAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "reject"]);
            return PutAsync<AssistanceRequestModel>(parameters, null, cancellationToken);
        }
    }
}
