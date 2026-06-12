using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    [UnsecureWebApiClient()]
    [WebApiRoute("api/user/v3/usergroups")]
    public sealed class UserGroupsWebApiClient : WebApiClientBase
    {
        public UserGroupsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<UserModelRequiredInfo?> GetDefaultRequiredInfoAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["default", "requiredinfo"]);
            return GetAsync<UserModelRequiredInfo?>(parameters, cancellationToken);
        }
    }
}
