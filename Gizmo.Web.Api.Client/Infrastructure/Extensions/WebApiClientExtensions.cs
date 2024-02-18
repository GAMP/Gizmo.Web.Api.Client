﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Adds secure web api clients to service collection.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <param name="clientName">Registered http client name.</param>
        /// <param name="configureClient">Http client configuration.</param>
        /// <returns>Web api client builder.</returns>
        /// <remarks>
        /// This function will add any api client that does not have <see cref="UnsecureWebApiClientAttribute"/> applied to it.
        /// </remarks>
        public static IWebApiClientBuilder AddSecureWebApiClients(this IServiceCollection services, string clientName,  Action<IServiceProvider, HttpClient> configureClient)
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

            var httpWebApiClientTypes = Assembly.GetExecutingAssembly().ExportedTypes.ToArray();
            var httpClientBuilders = new List<IHttpClientBuilder>(httpWebApiClientTypes.Length);

            //add each web api client
            foreach (var clientType in httpWebApiClientTypes)
            {
                //get type info
                var typeInfo = clientType.GetTypeInfo();

                //any type that inherits from web api client base added as singelton service
                if (typeInfo.BaseType == typeof(WebApiClientBase))
                {
                    //check if the web api client is unsecure, in such cases it should not be added
                    var unsecureAttribute = typeInfo.GetCustomAttribute<UnsecureWebApiClientAttribute>();
                    if (unsecureAttribute != null)
                        continue;

                    //invoke the method
                    var httpClientBuilder = (IHttpClientBuilder)httpMethod
                        .MakeGenericMethod(clientType)
                        .Invoke(null, new object[] { services, clientName, configureClient })!;
                  
                    httpClientBuilders.Add(httpClientBuilder);
                }
            }

            return new WebApiClientBuilder(services, httpClientBuilders);
        }

        /// <summary>
        /// Adds unsesecured web api clients to service collection.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <param name="clientName">Registered http client name.</param>
        /// <param name="configureClient">Http client configuration.</param>
        /// <returns>Web api client builder.</returns>
        /// <remarks>
        /// This function will add any api client that have <see cref="UnsecureWebApiClientAttribute"/> applied to it.
        /// </remarks>
        public static IWebApiClientBuilder AddUnsecureWebApiClients(this IServiceCollection services, string clientName, Action<IServiceProvider, HttpClient> configureClient)
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

            var httpWebApiClientTypes = Assembly.GetExecutingAssembly().ExportedTypes.ToArray();
            var httpClientBuilders = new List<IHttpClientBuilder>(httpWebApiClientTypes.Length);

            //add each web api client
            foreach (var clientType in httpWebApiClientTypes)
            {
                //get type info
                var typeInfo = clientType.GetTypeInfo();

                //any type that inherits from web api client base added as singelton service
                if (typeInfo.BaseType == typeof(WebApiClientBase))
                {
                    //check if the web api client is unsecure, only unsecured clients should be added
                    var unsecureAttribute = typeInfo.GetCustomAttribute<UnsecureWebApiClientAttribute>();

                    if (unsecureAttribute != null)
                    {
                        //invoke the method
                        var httpClientBuilder = (IHttpClientBuilder)httpMethod
                            .MakeGenericMethod(clientType)
                            .Invoke(null, new object[] { services, clientName, configureClient })!;

                        httpClientBuilders.Add(httpClientBuilder);
                    }
                }
            }

            return new WebApiClientBuilder(services, httpClientBuilders);
        }
    }
}
