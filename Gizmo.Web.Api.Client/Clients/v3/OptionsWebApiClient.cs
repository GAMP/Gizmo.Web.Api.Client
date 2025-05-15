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
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
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

        public Task<TopUpOptions> TopUpAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["topup"]);
            return GetAsync<TopUpOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> TopUpPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["topup", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> TopUpAsync(TopUpOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["topup"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<PaymentProcessingOptions> PaymentProcessingAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["paymentprocessing"]);
            return GetAsync<PaymentProcessingOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> PaymentProcessingPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["paymentprocessing", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> PaymentProcessingAsync(PaymentProcessingOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["paymentprocessing"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<SMTPOptions> SMTPAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["smtp"]);
            return GetAsync<SMTPOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> SMTPPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["smtp", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> SMTPAsync(SMTPOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["smtp"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<SMSGatewayOptions> SmsGatewayAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["smsgateway"]);
            return GetAsync<SMSGatewayOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> SmsGatewayPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["smsgateway", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> SmsGatewayAsync(SMSGatewayOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["smsgateway"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<NetworkOptions> NetworkAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["network"]);
            return GetAsync<NetworkOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> NetworkPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["network", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> NetworkAsync(NetworkOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["network"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<ClientNetworkConnectionOptions> ClientNetworkConnectionAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["client", "network", "connection"]);
            return GetAsync<ClientNetworkConnectionOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> ClientNetworkConnectionPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["client", "network", "connection", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> ClientNetworkConnectionAsync(ClientNetworkConnectionOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["client", "network", "connection"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<HttpsCertificateOptions> HttpsCertificateAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["https", "certificate"]);
            return GetAsync<HttpsCertificateOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> HttpsCertificatePackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["https", "certificate", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> HttpsCertificateAsync(HttpsCertificateOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["https", "certificate"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<UserSessionsOptions> UserSessionsAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "sessions"]);
            return GetAsync<UserSessionsOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> UserSessionsPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "sessions", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UserSessionsAsync(UserSessionsOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "sessions"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<UserLoginOptions> UserLoginAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "login"]);
            return GetAsync<UserLoginOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> UserLoginPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "login", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UserLoginAsync(UserLoginOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "login"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<MiscOptions> MiscAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["misc"]);
            return GetAsync<MiscOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> MiscPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["misc", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> MiscAsync(MiscOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["misc"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<ClientUpdateOptions> ClientUpdateAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["client", "update"]);
            return GetAsync<ClientUpdateOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> ClientUpdatePackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["client", "update", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> ClientUpdateAsync(ClientUpdateOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["client", "update"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<ClientGeneralOptions> ClientAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["client"]);
            return GetAsync<ClientGeneralOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> ClientPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["client", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> ClientAsync(ClientGeneralOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["client"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<ConfirmationCodeOptions> ConfirmationCodeAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["confirmation", "code"]);
            return GetAsync<ConfirmationCodeOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> ConfirmationCodePackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["confirmation", "code", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> ConfirmationCodeAsync(ConfirmationCodeOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["confirmation", "code"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<UserPasswordPolicyOptions> UserPasswordPolicyAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "password", "policy"]);
            return GetAsync<UserPasswordPolicyOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> UserPasswordPolicyPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "password", "policy", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UserPasswordPolicyAsync(UserPasswordPolicyOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "password", "policy"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<UserPasswordRecoveryOptions> UserPasswordRecoveryAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "password", "recovery"]);
            return GetAsync<UserPasswordRecoveryOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> UserPasswordRecoveryPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "password", "recovery", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UserPasswordRecoveryAsync(UserPasswordRecoveryOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "password", "recovery"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<UserRegistrationOptions> UserUserRegistrationAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "registration"]);
            return GetAsync<UserRegistrationOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> UserUserRegistrationPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "registration", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UserUserRegistrationAsync(UserRegistrationOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "registration"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<UserLogoutGraceOptions> UserLogoutGraceAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "logout", "grace"]);
            return GetAsync<UserLogoutGraceOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> UserLogoutGracePackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "logout", "grace", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UserLogoutGraceAsync(UserLogoutGraceOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "logout", "grace"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<UserFilesOptions> UserFilesAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "files"]);
            return GetAsync<UserFilesOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> UserFilesPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "files", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UserFilesAsync(UserFilesOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "files"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<UserStorageOptions> UserStorageAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "storage"]);
            return GetAsync<UserStorageOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> UserStoragePackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "storage", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UserStorageAsync(UserStorageOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "storage"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<DeploymentOptions> DeploymentAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["deployment"]);
            return GetAsync<DeploymentOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> DeploymentPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["deployment", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> DeploymentAsync(DeploymentOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["deployment"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<ClientNotificationOptions> ClientNotificationsAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["client", "notifications"]);
            return GetAsync<ClientNotificationOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> ClientNotificationsPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["client", "notifications", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> ClientNotificationsAsync(ClientNotificationOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["client", "notifications"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<UserBalanceOptions> UserBalanceAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "balance"]);
            return GetAsync<UserBalanceOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> UserBalancePackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "balance", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UserBalanceAsync(UserBalanceOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user", "balance"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<InvoicingOptions> InvoicingAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["invoicing"]);
            return GetAsync<InvoicingOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> InvoicingPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["invoicing", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> InvoicingAsync(InvoicingOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["invoicing"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }

        public Task<POSAutomationOptions> POSAutomationAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["pos", "automation"]);
            return GetAsync<POSAutomationOptions>(parameters, cancellationToken);
        }

        public Task<StoreOptionsReadPack> POSAutomationPackAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["pos", "automation", "pack"]);
            return GetAsync<StoreOptionsReadPack>(parameters, cancellationToken);
        }

        public Task<UpdateResult> POSAutomationAsync(POSAutomationOptions options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["post", "automation"]);
            return PostAsync<UpdateResult>(parameters, options, cancellationToken);
        }
    }
}
