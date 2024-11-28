using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Server.Options;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;

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
        /// Reads store options.
        /// </summary>
        /// <typeparam name="TOptions">Options type.</typeparam>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Options read pack.</returns>
        public Task<StoreOptionsReadPack> ReadAsync<TOptions>(CancellationToken cancellationToken = default) where TOptions : IStoreOptions
        {
            var optionsType = typeof(TOptions).GetShortTypeName();
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
            return PutAsync<UpdateResult>(UriParameters.Empty, storeOptionsWrite, cancellationToken);
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

        public Task<UpdateResult> CurrencyAsync(CurrencyOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["currency"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
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

        public Task<UpdateResult> BusinessAsync(BusinessOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["business"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
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

        public Task<UpdateResult> GeneralAsync(GeneralOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["general"]);
            return PostAsync<UpdateResult>(parameters,options, cancellationToken);
        }

        public Task<ManagerFeaturesOptions> ManagerFeaturesAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["managerfeatures"]);
            return GetAsync<ManagerFeaturesOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> ManagerFeaturesPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["managerfeatures", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> ManagerFeaturesAsync(ManagerFeaturesOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["managerfeatures"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<SubscriptionOptions> SubscriptionAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["subscription"]);
            return GetAsync<SubscriptionOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> SubscriptionPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["subscription", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> SubscriptionAsync(SubscriptionOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["subscription"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<RegionalOptions> RegionalAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["regional"]);
            return GetAsync<RegionalOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> RegionalPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["regional", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> RegionalAsync(RegionalOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["regional"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<FiscalizationOptions> FiscalizationAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["fiscalization"]);
            return GetAsync<FiscalizationOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> FiscalizationPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["fiscalization", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> FiscalizationAsync(FiscalizationOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["fiscalization"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<TaxOptions> TaxAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["tax"]);
            return GetAsync<TaxOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> TaxPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["tax", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> TaxAsync(TaxOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["tax"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<ReservationsOptions> ReservationsAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["reservations"]);
            return GetAsync<ReservationsOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> ReservationsPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["reservations", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> ReservationsAsync(ReservationsOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["reservations"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<AgeRestrictionsOptions> AgeRestrictionsAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["agerestrictions"]);
            return GetAsync<AgeRestrictionsOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> AgeRestrictionsPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["agerestrictions", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> AgeRestrictionsAsync(AgeRestrictionsOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["agerestrictions"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<WaitingLinesOptions> WaitingLinesAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["waitinglines"]);
            return GetAsync<WaitingLinesOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> WaitingLinesPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["waitinglines", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> WaitingLinesAsync(WaitingLinesOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["waitinglines"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }
    }
}
