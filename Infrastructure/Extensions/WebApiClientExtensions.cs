using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Reflection;

namespace Gizmo.Web.Api.Client.Builder
{
    /// <summary>
    /// Web api client extensions.
    /// </summary>
    public static class WebApiClientExtensions
    {
        /// <summary>
        /// Adds web api clients to service collection.
        /// </summary>
        /// <param name="services">Service collection.</param>
        public static IWebApiClientBuilder AddWebApiClient(this IServiceCollection services)
        {
            return AddWebApiClient(services, _ => { });
        }

        /// <summary>
        /// Adds web api clients to service collection.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <param name="configure">Configuration action.</param>
        /// <returns>Web api client builder.</returns>
        public static IWebApiClientBuilder AddWebApiClient(this IServiceCollection services, Action<WebApiClientOptions> configure)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IPayloadSerializerProvider, DefaultPayloadSerializerProvider>());
       
            foreach (var type in Assembly.GetExecutingAssembly().ExportedTypes)
            {
                //get type info
                var typeInfo = type.GetTypeInfo();

                //attributes can be checked here for client exclusion e.t.c

                //any type that inherits from web api client base added as singelton service
                if (typeInfo.BaseType == typeof(WebApiClientBase))
                    services.AddSingleton(type);
            }

            services.Configure(configure);

            return new WebApiClientBuilder(services);
        }

        public static IWebApiClientBuilder AddSecureWebApiClient(this IServiceCollection services, 
            string secureHttpClientName,
            Action<WebApiClientOptions> configure)
        {
            if (string.IsNullOrWhiteSpace(secureHttpClientName))
                throw new ArgumentNullException(nameof(secureHttpClientName));

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IPayloadSerializerProvider, DefaultPayloadSerializerProvider>());

            services.AddHttpClient<UsersWebApiClient>(secureHttpClientName);
            services.AddHttpClient<ProductsWebApiClient>(secureHttpClientName);
            services.AddHttpClient<PaymentMethodWebApiClient>(secureHttpClientName);
            services.AddHttpClient<VariableWebApiClient>(secureHttpClientName);
            services.AddHttpClient<AssetsWebApiClient>(secureHttpClientName);
            services.AddHttpClient<AssetTypesWebApiClient>(secureHttpClientName);
            services.AddHttpClient<AttributesWebApiClient>(secureHttpClientName);
            services.AddHttpClient<HostGroupsWebApiClient>(secureHttpClientName);
            services.AddHttpClient<HostIconWebApiClient>(secureHttpClientName);
            services.AddHttpClient<HostWebApiClient>(secureHttpClientName);
            services.AddHttpClient<MonetaryUnitsWebApiClient>(secureHttpClientName);
            services.AddHttpClient<OperatorsWebApiClient>(secureHttpClientName);
            services.AddHttpClient<ProductGroupsWebApiClient>(secureHttpClientName);
            services.AddHttpClient<RegisterWebApiClient>(secureHttpClientName);
            services.AddHttpClient<TaxesWebApiClient>(secureHttpClientName);
            services.AddHttpClient<UserGroupsWebApiClient>(secureHttpClientName);
            services.AddHttpClient<VariableWebApiClient>(secureHttpClientName);

            services.Configure(configure);

            return new WebApiClientBuilder(services);
        }
    }
}
