using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    [WebApiRoute("api/user/v2/assistancerequests")]
    public sealed class AssistanceRequestsWebApiClient : WebApiClientBase
    {
        public AssistanceRequestsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<bool> PendingAnyAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["pending", "any"]);
            return GetAsync<bool>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(AssistanceRequestModelUserCreate createModel, CancellationToken cancellationToken = default)
        {
            return PostAsync<CreateResult>(UriParameters.Empty, createModel, cancellationToken);
        }

        public Task<UpdateResult> CancelAsync(CancellationToken cancellationToken = default)
        {
            return DeleteAsync<UpdateResult>(UriParameters.Empty, cancellationToken);
        }
    }
}
