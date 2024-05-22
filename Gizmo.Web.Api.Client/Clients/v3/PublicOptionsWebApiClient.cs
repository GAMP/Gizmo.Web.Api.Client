using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Server.Options;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Public options web api client.
    /// </summary>
    [UnsecureWebApiClient()]
    [WebApiRoute("api/v3/publicoptions")]
    public sealed class PublicOptionsWebApiClient : WebApiClientBase
    {
        /// <inheritdoc cref="WebApiClientBase(HttpClient, IOptions{WebApiClientOptions}, IPayloadSerializerProvider)"/>
        public PublicOptionsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
          base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<GeneralOptions> GeneralAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["general"]);
            return GetAsync<GeneralOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> GeneralPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["general","pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }
    }
}
