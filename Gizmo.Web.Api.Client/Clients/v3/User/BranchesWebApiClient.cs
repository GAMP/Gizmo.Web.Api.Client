using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    /// <summary>
    /// Branches api client, user surface — the active branches (clubs) visible to the authenticated user.
    /// </summary>
    [WebApiRoute("api/user/v3/branches")]
    public sealed class BranchesWebApiClient : WebApiClientBase
    {
        public BranchesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        /// <summary>
        /// Gets the active branches ordered by name, optionally of one city.
        /// </summary>
        public Task<PagedList<UserBranchModel>> GetAsync(UserBranchesFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<UserBranchModel>>(parameters, cancellationToken);
        }

        /// <summary>
        /// Gets the distinct cities of the active branches.
        /// </summary>
        public Task<IEnumerable<string>> GetCitiesAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["cities"]);
            return GetAsync<IEnumerable<string>>(parameters, cancellationToken);
        }

        /// <summary>
        /// Gets the active branch by id with its computer counts and host group names.
        /// </summary>
        public Task<UserBranchDetailsModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<UserBranchDetailsModel>(parameters, cancellationToken);
        }
    }
}
