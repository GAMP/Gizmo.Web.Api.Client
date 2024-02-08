using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Store options web api client.
    /// </summary>
    [WebApiRoute("api/v2/storeoptions")]
    public sealed class StoreOptionsWebApiClient : WebApiClientBase
    {
        /// <inheritdoc cref="WebApiClientBase(HttpClient, IOptions{WebApiClientOptions}, IPayloadSerializerProvider)"/>
        public StoreOptionsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
          base(httpClient, options, payloadSerializerProvider)
        {
        }

        /// <summary>
        /// Reads store options.
        /// </summary>
        /// <param name="optionsType">Options type.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Options read pack.</returns>
        public Task<StoreOptionsReadPack> ReadAsync(string optionsType, CancellationToken cancellationToken = default)
        {
            var queryParameters = new Dictionary<string, string>() { { "optionsType" , optionsType } };
            var parameters = new UriParameters([], queryParameters);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        /// <summary>
        /// Writes options to store.
        /// </summary>
        /// <param name="storeOptionsWrite">Options write pack.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Update result.</returns>
        public Task<UpdateResult> WriteAsync(StoreOptionsWritePack storeOptionsWrite, CancellationToken cancellationToken = default)
        {
            return PostAsync<UpdateResult>(UriParameters.Empty, storeOptionsWrite, cancellationToken);
        }
    }
}
