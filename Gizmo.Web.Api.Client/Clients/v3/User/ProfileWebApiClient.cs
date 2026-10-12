using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    [WebApiRoute("api/user/v3/profile")]
    public sealed class ProfileWebApiClient : WebApiClientBase
    {
        public ProfileWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<UpdateResult> UpdateAsync(UserProfileModelUserUpdate model, CancellationToken cancellationToken = default)
        {
            return PutAsync<UpdateResult>(UriParameters.Empty, model, cancellationToken);
        }
    }
}
