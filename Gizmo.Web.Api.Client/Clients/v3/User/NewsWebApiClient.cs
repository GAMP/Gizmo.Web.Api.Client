using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    /// <summary>
    /// News api client, user surface — the news visible to the authenticated user.
    /// </summary>
    [WebApiRoute("api/user/v3/news")]
    public sealed class NewsWebApiClient : WebApiClientBase
    {
        public NewsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        /// <summary>
        /// Gets the active news enabled in at least one active branch.
        /// </summary>
        public Task<PagedList<NewsModel>> GetAsync(NewsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<NewsModel>>(parameters, cancellationToken);
        }

        /// <summary>
        /// Gets a visible news item by id.
        /// </summary>
        public Task<NewsModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<NewsModel>(parameters, cancellationToken);
        }
    }
}
