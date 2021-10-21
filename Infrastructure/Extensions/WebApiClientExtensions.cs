using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Linq;
using System.Reflection;

namespace Gizmo.Web.Api.Client.Builder
{
    /// <summary>
    /// Web api client extensions.
    /// </summary>
    public static class WebApiClientExtensions
    {
        #region PRIVATE STATIC READONLY
        private static readonly Type _extensionType = typeof(HttpClientFactoryServiceCollectionExtensions);
        #endregion

        #region EXTENSION METHODS
        
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
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IPayloadSerializerProvider, DefaultPayloadSerializerProvider>());

            //get all the extension methods
            var methods = _extensionType.GetMethods(BindingFlags.Static | BindingFlags.Public);

            //find desired http client method
            var httpMethod = methods.Where(mi => mi.Name == "AddHttpClient" && mi.IsGenericMethod && mi.GetParameters().Count() == 2)
                .FirstOrDefault();

            //check if the desired method is found
            if (httpMethod == null)
                throw new NotSupportedException();

            //add each web api client
            foreach (var type in Assembly.GetExecutingAssembly().ExportedTypes)
            {
                //get type info
                var typeInfo = type.GetTypeInfo();

                //attributes can be checked here for client exclusion e.t.c

                //any type that inherits from web api client base added as singelton service
                if (typeInfo.BaseType == typeof(WebApiClientBase))
                {
                    //invoke the method
                    httpMethod.MakeGenericMethod(new Type[] { type })
                        .Invoke(null, new object[] { services, clientName });
                }
            }

            //configure options
            services.Configure(configure);

            //return builder
            return new WebApiClientBuilder(services);
        } 

        #endregion
    }
}
