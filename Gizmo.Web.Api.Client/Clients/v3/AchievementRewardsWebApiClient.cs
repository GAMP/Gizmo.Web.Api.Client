using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/achievementrewards")]
    public sealed class AchievementRewardsWebApiClient : WebApiClientBase
    {
        public AchievementRewardsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        /// <summary>
        /// Gets earned rewards with their fulfillment states. Filter by status to get the claim
        /// queue, and by user or challenge to narrow it.
        /// </summary>
        public Task<PagedList<UserAchievementRewardModel>> GetAsync(UserAchievementRewardsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<UserAchievementRewardModel>>(parameters, cancellationToken);
        }

        /// <summary>
        /// Gets how many rewards sit in each status, for every user or narrowed to one user or
        /// challenge — the totals the paged rows cannot supply.
        /// </summary>
        public Task<UserAchievementRewardCountsModel> GetCountsAsync(UserAchievementRewardCountsFilter? filter = null, CancellationToken cancellationToken = default)
        {
            var parameters = filter is null
                ? new UriParameters(["counts"])
                : new UriParameters(["counts"], filter);
            return GetAsync<UserAchievementRewardCountsModel>(parameters, cancellationToken);
        }

        /// <summary>
        /// Claims a reward for its user — the operator confirms the handover.
        /// </summary>
        public Task<UpdateResult> ClaimAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "claim"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        /// <summary>
        /// Declines a reward — nothing is delivered.
        /// </summary>
        public Task<UpdateResult> DeclineAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "decline"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        /// <summary>
        /// Re-offers a declined reward, putting it back in the claim queue.
        /// </summary>
        public Task<UpdateResult> ReofferAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "reoffer"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }
    }
}
