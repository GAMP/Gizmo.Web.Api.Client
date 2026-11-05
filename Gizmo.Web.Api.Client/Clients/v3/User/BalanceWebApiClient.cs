using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    /// <summary>
    /// Balance api client, user surface — the authenticated user's own balance.
    /// </summary>
    [WebApiRoute("api/user/v3/balance")]
    public sealed class BalanceWebApiClient : WebApiClientBase
    {
        public BalanceWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        /// <summary>
        /// Gets the balance of the authenticated user.
        /// </summary>
        public Task<UserBalanceExtendedModel> GetAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return GetAsync<UserBalanceExtendedModel>(parameters, cancellationToken);
        }
    }
}
