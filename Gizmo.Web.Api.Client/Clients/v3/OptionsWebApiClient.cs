using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Server.Options;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Options web api client.
    /// </summary>
    [WebApiRoute("api/v3/options")]
    public sealed class OptionsWebApiClient : WebApiClientBase
    {
        /// <inheritdoc cref="WebApiClientBase(HttpClient, IOptions{WebApiClientOptions}, IPayloadSerializerProvider)"/>
        public OptionsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
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
            var queryParameters = new Dictionary<string, string>() { { "optionsType", optionsType } };
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

        public Task<GeneralOptions> GeneralAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["general"]);
            return GetAsync<GeneralOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> GeneralPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["general", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<CurrencyOptions> CurrencyAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["currency"]);
            return GetAsync<CurrencyOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> CurrencyPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["currency", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<BusinessOptions> BusinessAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["business"]);
            return GetAsync<BusinessOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> BusinessPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["business", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }
    }
}
