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
        public ProfileWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<UserProfileModel> GetAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return GetAsync<UserProfileModel>(parameters, cancellationToken);
        }

        public Task<UserModelRequiredInfo> GetRequiredInfoAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["requiredinfo"]);
            return GetAsync<UserModelRequiredInfo>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(UserProfileModelUserUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }
    }
}
