using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Polly;

namespace Gizmo.Web.Api.Clients.Builder
{
    /// <summary>
    /// Web api client builder.
    /// </summary>
    internal class WebApiClientBuilder : IWebApiClientBuilder
    {
        #region CONSTRCUTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="services">Services collection.</param>
        public WebApiClientBuilder(IServiceCollection services, IEnumerable<IHttpClientBuilder> httpClientBuilders)
        {
            _services = services;
            _httpClientBuilders = httpClientBuilders;
        }

        #endregion

        #region FEILDS

        private readonly IServiceCollection _services;
        private readonly IEnumerable<IHttpClientBuilder> _httpClientBuilders;

        #endregion

        #region FUNTIONS

        public IWebApiClientBuilder WithJsonSerialization()
        {
            return WithJsonSerialization(_ => { });
        }

        public IWebApiClientBuilder WithJsonSerialization(Action<JsonPayloadSerializerOptions> configure)
        {
            _services.TryAddEnumerable(ServiceDescriptor.Singleton<IPayloadSerializer, JsonPayloadSerializer>());
            _services.Configure(configure);
            return this;
        }

        public IWebApiClientBuilder WithMessagePackSerialization()
        {
            return WithMessagePackSerialization(_ => { });
        }

        public IWebApiClientBuilder WithMessagePackSerialization(Action<MessagePackPayloadSerializerOptions> configure)
        {
            _services.TryAddEnumerable(ServiceDescriptor.Singleton<IPayloadSerializer, MessagePackPayloadSerializer>());
            _services.Configure(configure);
            return this;
        }

        public IWebApiClientBuilder WithMessageHandler<THandler>() where THandler : DelegatingHandler
        {
            foreach (var httpClient in _httpClientBuilders)
                httpClient.AddHttpMessageHandler<THandler>();

            return this;
        }

        public IWebApiClientBuilder WithAdditionalOptions(string clientName, Action<WebApiClientOptions> options)
        {
            _services.Configure(clientName, options);
            return this;
        }

        public IWebApiClientBuilder WithRetryPolicyHandler(int retryCount)
        {
            var retryPolicy = Policy
                    .HandleResult<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized && m.Headers.Contains("token-expired"))
                    .WaitAndRetryAsync(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            foreach (var httpClient in _httpClientBuilders)
                httpClient.AddPolicyHandler(retryPolicy);

            return this;
        }

        public IWebApiClientBuilder WithTimeoutPolicyHandler(int timeoutSeconds)
        {
            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(timeoutSeconds));

            foreach (var httpClient in _httpClientBuilders)
                httpClient.AddPolicyHandler(timeoutPolicy);

            return this;
        }

        public IWebApiClientBuilder ConfigurePrimaryHttpMessageHandler<THandler>(Func<THandler> configure) where THandler : HttpMessageHandler
        {
            foreach (var httpClient in _httpClientBuilders)
                httpClient.ConfigurePrimaryHttpMessageHandler(configure);

            return this;
        }

        public IWebApiClientBuilder AddCurrentUICultureDelegatingHandler()
        {
            _services.AddTransient<CurrentUICultureDelegatingHandler>();

            foreach (var httpClient in _httpClientBuilders)
                httpClient.AddHttpMessageHandler<CurrentUICultureDelegatingHandler>();

            return this;
        }

        #endregion
    }
}
