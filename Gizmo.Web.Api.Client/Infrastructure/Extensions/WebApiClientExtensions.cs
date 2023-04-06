using System;
using System.Net.Http;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Gizmo.Web.Api.Clients.Builder
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
        /// <param name="clientName">Registered http client name.</param>
        /// <param name="configureClient">Http client configuration.</param>
        /// <returns>Web api client builder.</returns>
        public static IWebApiClientBuilder AddWebApiClient(this IServiceCollection services, string clientName, Action<IServiceProvider, HttpClient> configureClient, Action<WebApiClientOptions> configureOptions)
        {
            //add payload serializer
            services.AddSingleton<IPayloadSerializerProvider, DefaultPayloadSerializerProvider>();

            //find desired http client method
            var httpMethod = Array.Find(typeof(HttpClientFactoryServiceCollectionExtensions).GetMethods(BindingFlags.Static | BindingFlags.Public),
                    methodInfo =>
                    methodInfo.Name == nameof(HttpClientFactoryServiceCollectionExtensions.AddHttpClient)
                    && methodInfo.IsGenericMethod
                    && methodInfo.GetParameters().Length == 3
                    && methodInfo.GetParameters()[2].ParameterType == typeof(Action<IServiceProvider, HttpClient>));

            if (httpMethod == null)
                throw new NotSupportedException("Unable to find AddHttpClient method.");

            //add each web api client
            foreach (var assemblyType in Assembly.GetExecutingAssembly().ExportedTypes)
            {
                //get type info
                var typeInfo = assemblyType.GetTypeInfo();

                //attributes can be checked here for client exclusion e.t.c

                //any type that inherits from web api client base added as singelton service
                if (typeInfo.BaseType == typeof(WebApiClientBase))
                {
                    //invoke the method
                    httpMethod
                        .MakeGenericMethod(assemblyType)
                        .Invoke(null, new object[] { services, clientName, configureClient });
                }
            }

            services.Configure(clientName, configureOptions);

            return new WebApiClientBuilder(services, clientName);
        }
    }
}
