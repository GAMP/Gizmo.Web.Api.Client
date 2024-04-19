using System;
using System.Globalization;
using System.Net.Http;

namespace Gizmo.Web.Api.Clients.Builder
{
    public interface IWebApiClientBuilder
    {
        IWebApiClientBuilder WithJsonSerialization();
        IWebApiClientBuilder WithJsonSerialization(Action<JsonPayloadSerializerOptions> configure);
        IWebApiClientBuilder WithMessagePackSerialization();
        IWebApiClientBuilder WithMessagePackSerialization(Action<MessagePackPayloadSerializerOptions> configure);
        IWebApiClientBuilder WithMessageHandler<THandler>() where THandler : DelegatingHandler;
        IWebApiClientBuilder WithAdditionalOptions(string clientName, Action<WebApiClientOptions> options);
        IWebApiClientBuilder WithRetryPolicyHandler(int retryCount);
        IWebApiClientBuilder WithTimeoutPolicyHandler(int timeoutSeconds);
        IWebApiClientBuilder ConfigurePrimaryHttpMessageHandler<THandler>(Func<THandler> configure) where THandler : HttpMessageHandler;

        /// <summary>
        /// Adds current UI culture delegating handler.
        /// </summary>
        /// <remarks>
        /// The handler will automatically add <see cref="CultureInfo.CurrentUICulture"/> value to AcceptLanguage header in <see cref="HttpRequestMessage.Headers"/>. 
        /// </remarks>
        /// <returns>WebApiClient builder.</returns>
        IWebApiClientBuilder WithCurrentUICultureMessageHandler();
    }
}
