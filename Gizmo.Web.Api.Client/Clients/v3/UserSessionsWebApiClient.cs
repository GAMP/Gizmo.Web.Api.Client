using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/usersessions")]
    public sealed class UserSessionsWebApiClient : WebApiClientBase
    {
        public UserSessionsWebApiClient(HttpClient httpClient,
            IOptions<WebApiClientOptions> options, 
            IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<UserSessionModel>> GetAsync(UserSessionFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<UserSessionModel>>(parameters, cancellationToken);
        }

        public Task<UserSessionModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<UserSessionModel>(parameters, cancellationToken);
        }
    }
}
