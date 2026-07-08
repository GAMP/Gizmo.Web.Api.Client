using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    [UnsecureWebApiClient()]
    [WebApiRoute("api/user/v3/users")]
    public sealed class UsersWebApiClient : WebApiClientBase
    {
        public UsersWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<bool> UsernameExistAsync(string username, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["username", "exist"], new Dictionary<string, string> { ["username"] = username });
            return GetAsync<bool>(parameters, cancellationToken);
        }

        public Task<bool> EmailExistAsync(string email, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["email", "exist"], new Dictionary<string, string> { ["email"] = email });
            return GetAsync<bool>(parameters, cancellationToken);
        }

        public Task<bool> MobilePhoneExistAsync(string mobilePhone, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["mobilephone", "exist"], new Dictionary<string, string> { ["mobilePhone"] = mobilePhone });
            return GetAsync<bool>(parameters, cancellationToken);
        }
    }
}
