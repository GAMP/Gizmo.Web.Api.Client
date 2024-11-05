using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Gizmo.Web.Api.Models;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/feeds")]
    public sealed class FeedsWebApiClient : WebApiClientBase
    {
        public FeedsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<FeedModel>> GetAsync(FeedsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<FeedModel>>(parameters, cancellationToken);
        }

        public Task<FeedModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<FeedModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(FeedCreateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(FeedUpdateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<IEnumerable<BranchReferenceModel>> BranchesGetAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "branches"]);
            return GetAsync<IEnumerable<BranchReferenceModel>>(parameters, cancellationToken);
        }

        public Task<UpdateResult> BranchSetAsync(int id, IEnumerable<BranchReferenceUpdateModel> entries, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "branches"]);
            return PostAsync<UpdateResult>(parameters, entries, cancellationToken);
        }
    }
}
