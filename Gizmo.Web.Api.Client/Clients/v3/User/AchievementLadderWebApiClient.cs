using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    /// <summary>
    /// Ladder aggregate api client, user surface — the authenticated user's own standing.
    /// Same payload shape as the operator client by design.
    /// </summary>
    [WebApiRoute("api/user/v3/ladder")]
    public sealed class AchievementLadderWebApiClient : WebApiClientBase
    {
        public AchievementLadderWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        /// <summary>
        /// Gets the ladder standing — every level with the live completion of it, the
        /// projected landing, perks, and the newest transitions. Null when there is no level
        /// to display: no enabled ladder, the user's group is not a ladder level, or a guest.
        /// Pass a filter with Progress false to skip the expensive live measurement and
        /// receive the full structure with every measurement-derived field null.
        /// </summary>
        public Task<LadderStandingModel> GetStandingAsync(LadderStandingFilter filter = null, CancellationToken cancellationToken = default)
        {
            var parameters = filter is null
                ? new UriParameters(["standing"])
                : new UriParameters(["standing"], filter);
            return GetAsync<LadderStandingModel>(parameters, cancellationToken);
        }

        /// <summary>
        /// Gets the ladder transition history, paged.
        /// </summary>
        public Task<PagedList<UserAchievementLadderEventModel>> GetEventsAsync(UserAchievementLadderEventsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["events"], filter);
            return GetAsync<PagedList<UserAchievementLadderEventModel>>(parameters, cancellationToken);
        }
    }
}
