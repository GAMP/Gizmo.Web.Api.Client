using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/achievements")]
    public sealed class AchievementsWebApiClient : WebApiClientBase
    {
        public AchievementsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<AchievementModel>> GetAsync(AchievementsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<AchievementModel>>(parameters, cancellationToken);
        }

        public Task<AchievementModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<AchievementModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(AchievementModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(AchievementModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UndeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "undelete"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<UpdateResult> EnableAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "enable"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<UpdateResult> DisableAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "disable"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<IReadOnlyList<AchievementSignalModel>> GetSignalsAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["signals"]);
            return GetAsync<IReadOnlyList<AchievementSignalModel>>(parameters, cancellationToken);
        }

        /// <summary>
        /// Gets a user's achievements view as the user sees it — the visible catalog with
        /// lifetime completions, current-instance standing, live progress and state per
        /// achievement. An unknown user id fails the standard entity-not-found way. Pass a
        /// filter with Progress false to skip the expensive live measurement, or with
        /// IncludeUnavailable false to list only what the user can still earn.
        /// </summary>
        public Task<UserAchievementsModel> GetUserAchievementsAsync(int userId, UserAchievementsFilter filter = null, CancellationToken cancellationToken = default)
        {
            var parameters = filter is null
                ? new UriParameters(["users", userId, "achievements"])
                : new UriParameters(["users", userId, "achievements"], filter);
            return GetAsync<UserAchievementsModel>(parameters, cancellationToken);
        }

        /// <summary>
        /// Gets a user's challenges view as the user sees it — the visible challenges with
        /// requirement progress, earned completions and their reward grant states. Null for an
        /// unknown user. Pass a filter with Progress false to skip the expensive live progress
        /// collection, or with IncludeUnavailable false to list only the challenges that are
        /// still open.
        /// </summary>
        public Task<UserAchievementChallengesModel> GetUserChallengesAsync(int userId, UserAchievementChallengesFilter filter = null, CancellationToken cancellationToken = default)
        {
            var parameters = filter is null
                ? new UriParameters(["users", userId, "challenges"])
                : new UriParameters(["users", userId, "challenges"], filter);
            return GetAsync<UserAchievementChallengesModel>(parameters, cancellationToken);
        }
    }
}
