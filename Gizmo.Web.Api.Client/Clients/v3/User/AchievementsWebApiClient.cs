using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    /// <summary>
    /// Achievements api client, user surface — the authenticated user's own achievements and
    /// challenges. Same payload shape as the operator client by design.
    /// </summary>
    [WebApiRoute("api/user/v3/achievements")]
    public sealed class AchievementsWebApiClient : WebApiClientBase
    {
        public AchievementsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        /// <summary>
        /// Gets the achievements view — the visible catalog with lifetime completions,
        /// current-instance standing, live progress and state per achievement. Pass a filter
        /// with Progress false to skip the expensive live measurement, or with
        /// IncludeUnavailable false to list only what can still be earned.
        /// </summary>
        public Task<UserAchievementsModel> GetAchievementsAsync(UserAchievementsFilter filter = null, CancellationToken cancellationToken = default)
        {
            var parameters = filter is null
                ? new UriParameters()
                : new UriParameters(filter);
            return GetAsync<UserAchievementsModel>(parameters, cancellationToken);
        }

        /// <summary>
        /// Gets the challenges view — the visible challenges with requirement progress, earned
        /// completions and their reward grant states. Pass a filter with Progress false to
        /// skip the expensive live progress collection, or with IncludeUnavailable false to
        /// list only the challenges that are still open.
        /// </summary>
        public Task<UserAchievementChallengesModel> GetChallengesAsync(UserAchievementChallengesFilter filter = null, CancellationToken cancellationToken = default)
        {
            var parameters = filter is null
                ? new UriParameters(["challenges"])
                : new UriParameters(["challenges"], filter);
            return GetAsync<UserAchievementChallengesModel>(parameters, cancellationToken);
        }
    }
}
