using System;
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
    }
}
