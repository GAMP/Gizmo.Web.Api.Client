using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Gizmo.Web.Api.Clients.Builder
{
    /// <summary>
    /// Configures app wide serialization options for the web api clients.
    /// </summary>
    public static class PayloadSerializerExtensions
    {
        #region FUNCTIONS
        
        public static TBuilder WithJsonSerialization<TBuilder>(this TBuilder builder) where TBuilder : IWebApiClientBuilder
        {
            return WithJsonSerialization(builder, _ => { });
        }

        public static TBuilder WithJsonSerialization<TBuilder>(this TBuilder builder, Action<JsonPayloadSerializerOptions> configure) where TBuilder : IWebApiClientBuilder
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPayloadSerializer, JsonPayloadSerializer>());
            builder.Services.Configure(configure);
            return builder;
        }

        public static TBuilder WithMessagePackSerialization<TBuilder>(this TBuilder builder) where TBuilder : IWebApiClientBuilder
        {
            return WithMessagePackSerialization(builder, _ => { });
        }

        public static TBuilder WithMessagePackSerialization<TBuilder>(this TBuilder builder, Action<MessagePackPayloadSerializerOptions> configure) where TBuilder : IWebApiClientBuilder
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPayloadSerializer, MessagePackPayloadSerializer>());
            builder.Services.Configure(configure);
            return builder;
        } 

        #endregion
    }
}
