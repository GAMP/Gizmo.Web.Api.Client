using Microsoft.Extensions.DependencyInjection;

using System;
using System.Linq;
using System.Reflection;

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
        /// <param name="configure">Configuration action.</param>
        /// <returns>Web api client builder.</returns>
        public static IWebApiClientBuilder AddWebApiClient(this IServiceCollection services, string clientName, Action<WebApiClientOptions> configure)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            //add payload serializer
            services.AddSingleton<IPayloadSerializerProvider, DefaultPayloadSerializerProvider>();

            //find desired http client method
            var httpMethod = typeof(HttpClientFactoryServiceCollectionExtensions)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(mi => 
                    mi.Name == nameof(HttpClientFactoryServiceCollectionExtensions.AddHttpClient) 
                    && mi.IsGenericMethod 
                    && mi.GetParameters().Length == 2)
                .FirstOrDefault();

            if (httpMethod == null)
                throw new NotSupportedException();

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
                        .MakeGenericMethod(new Type[] { assemblyType })
                        .Invoke(null, new object[] { services, clientName });
                }
            }

            //configure options
            services.Configure(configure);

            //return builder
            return new WebApiClientBuilder(services);
        } 
    }
}
