using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Ladder aggregate api client — the configuration singleton, per-user standings, and the
    /// paged transition event log.
    /// </summary>
    [WebApiRoute("api/v3/ladder")]
    public sealed class AchievementLadderWebApiClient : WebApiClientBase
    {
        public AchievementLadderWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        /// <summary>
        /// Gets the ladder, or a disabled default when none has been saved yet.
        /// The ladder is a singleton by design — one ladder exists in the system.
        /// </summary>
        public Task<AchievementLadderModel> GetAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return GetAsync<AchievementLadderModel>(parameters, cancellationToken);
        }

        /// <summary>
        /// Saves the ladder, creating it on first save.
        /// </summary>
        public Task<UpdateResult> SetAsync(AchievementLadderModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        /// <summary>
        /// Gets a user's ladder standing — every level with the user's live completion of it,
        /// the projected landing, perks, and the newest transitions. Null when there is no
        /// level to display: no enabled ladder, the user's group is not a ladder level, or a
        /// guest; an unknown user id fails the standard entity-not-found way. Pass a filter
        /// with Progress false to skip the expensive live measurement and receive the full
        /// structure with every measurement-derived field null.
        /// </summary>
        public Task<LadderStandingModel> GetUserStandingAsync(int userId, LadderStandingFilter? filter = null, CancellationToken cancellationToken = default)
        {
            var parameters = filter is null
                ? new UriParameters(["users", userId, "standing"])
                : new UriParameters(["users", userId, "standing"], filter);
            return GetAsync<LadderStandingModel>(parameters, cancellationToken);
        }

        /// <summary>
        /// Gets a user's ladder transition history as the user sees it, paged.
        /// </summary>
        public Task<PagedList<UserAchievementLadderEventModel>> GetUserEventsAsync(int userId, UserAchievementLadderEventsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["users", userId, "events"], filter);
            return GetAsync<PagedList<UserAchievementLadderEventModel>>(parameters, cancellationToken);
        }
    }
}
