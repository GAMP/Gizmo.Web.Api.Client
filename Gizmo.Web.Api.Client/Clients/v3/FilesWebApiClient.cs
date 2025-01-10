using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/files")]
    public sealed class FilesWebApiClient : WebApiClientBase
    {
        public FilesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<DeleteResult> HardDeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "hard"]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<long> DeletedSizeAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["deleted", "size"]);
            return GetAsync<long>(parameters, cancellationToken);
        }

        public Task<long> DeletedCountAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["deleted", "count"]);
            return GetAsync<long>(parameters, cancellationToken);
        }

        public Task<DeleteResult> PurgeAsync(CancellationToken cancellationToken = default) 
        {
            var parameters = new UriParameters(["purge"]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }
    }
}
