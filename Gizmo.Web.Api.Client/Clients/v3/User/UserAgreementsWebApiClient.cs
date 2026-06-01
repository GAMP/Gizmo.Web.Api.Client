using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    [UnsecureWebApiClient()]
    [WebApiRoute("api/user/v3/useragreements")]
    public sealed class UserAgreementsWebApiClient : WebApiClientBase
    {
        public UserAgreementsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<UserAgreementModel>> GetAsync(UserAgreementsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<UserAgreementModel>>(parameters, cancellationToken);
        }
    }
}
