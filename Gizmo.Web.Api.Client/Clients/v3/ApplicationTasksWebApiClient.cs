using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/applicationtasks")]
    public sealed class ApplicationTasksWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationTasksWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<IEnumerable<ApplicationTaskUsageModel>> GetUsagesAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "usages"]);
            return GetAsync<IEnumerable<ApplicationTaskUsageModel>>(parameters, ct);
        }

        public Task<UpdateResult> UnassignAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "unassign"]);
            return PutAsync<UpdateResult>(parameters, ct);
        }

        #endregion
    }
}
