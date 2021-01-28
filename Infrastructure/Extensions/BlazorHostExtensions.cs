using Gizmo.Web.Api.Client.Client;
using Microsoft.Extensions.DependencyInjection;

namespace Gizmo.Web.Api.Client
{
    /// <summary>
    /// Blazor host extensions.
    /// </summary>
    public static class BlazorHostExtensions
    {
        /// <summary>
        /// Adds web api clients to service collection.
        /// </summary>
        /// <param name="services">Service collection.</param>
        public static void AddWebApiClient(this IServiceCollection services)
        {
            services.AddSingleton<UsersWebApiClient>();
            services.AddSingleton<AuthenticationWebApiClient>();            
            services.AddSingleton<AttributesWebApiClient>();
            services.AddSingleton<HostGroupsWebApiClient>();
            services.AddSingleton<ProductGroupsWebApiClient>();
            services.AddSingleton<ProductsWebApiClient>();
            services.AddSingleton<UserGroupsWebApiClient>();
            services.AddSingleton<AuthenticationWebApiClient>();
            services.AddSingleton<AssetsWebApiClient>();
            services.AddSingleton<AssetTypesWebApiClient>();
            services.AddSingleton<HostIconWebApiClient>();
            services.AddSingleton<HostWebApiClient>();
            services.AddSingleton<MonetaryUnitsWebApiClient>();
            services.AddSingleton<PaymentMethodWebApiClient>();
            services.AddSingleton<RegisterWebApiClient>();
            services.AddSingleton<TaxesWebApiClient>();
            services.AddSingleton<VariableWebApiClient>();
            services.AddSingleton<TimeSalesPresetsWebApiClient>();
            services.AddSingleton<OperatorsWebApiClient>();
            services.AddSingleton<AuthenticationWebApiClient>();
            services.AddSingleton<OrdersWebApiClient>();
            services.AddSingleton<ApplicationCategoriesWebApiClient>();
            services.AddSingleton<ApplicationDeploymentsWebApiClient>();
            services.AddSingleton<ApplicationEnterprisesWebApiClient>();
            services.AddSingleton<ApplicationExecutablesWebApiClient>();
            services.AddSingleton<ApplicationGroupsWebApiClient>();
            services.AddSingleton<ApplicationLicensesWebApiClient>();
            services.AddSingleton<ApplicationPersonalFilesWebApiClient>();
            services.AddSingleton<ApplicationsWebApiClient>();
            services.AddSingleton<ApplicationTasksWebApiClient>();
            services.AddSingleton<BillingProfilesWebApiClient>();
            services.AddSingleton<DepositTransactionsWebApiClient>();
            services.AddSingleton<InvoicePaymentsWebApiClient>();
            services.AddSingleton<InvoicesWebApiClient>();
            services.AddSingleton<ProductsStockWebApiClient>();
            services.AddSingleton<RegisterTransactionsWebApiClient>();
        }
    }
}
