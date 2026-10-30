using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    /// <summary>
    /// User agreements pending for the current (authenticated) user.
    /// </summary>
    [WebApiRoute("api/user/v3/useragreements")]
    public sealed class PendingUserAgreementsWebApiClient : WebApiClientBase
    {
        public PendingUserAgreementsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<UserAgreementModel>> GetPendingAsync(UserAgreementsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "pending" }, filter);
            return GetAsync<PagedList<UserAgreementModel>>(parameters, cancellationToken);
        }

        public Task<UpdateResult> AcceptAsync(int userAgreementId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { userAgreementId, "accept" });
            return PutAsync<UpdateResult>(parameters, cancellationToken);
        }
    }
}
