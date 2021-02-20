using MessagePack;
using Microsoft.Extensions.Options;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    internal class MessagePackPayloadSerializer : IPayloadSerializer
    {
        #region CONSTRUCTOR

        public MessagePackPayloadSerializer(IOptions<MessagePackPayloadSerializerOptions> options)
        {
            SerializerOptions = options;
        }

        #endregion

        #region FIELDS

        private static readonly MediaTypeHeaderValue mediaTypeHeaderValue = new(MimeType.MSGPACK);

        #endregion

        #region PROPERTIES

        private IOptions<MessagePackPayloadSerializerOptions> SerializerOptions
        {
            get; set;
        }

        public string Name => "msgpack";

        #endregion

        #region IPayloadSerializer
        
        public ValueTask<T> DeserializeAsync<T>(Stream stream, CancellationToken ct)
        {
            return MessagePackSerializer.DeserializeAsync<T>(stream, SerializerOptions.Value.MessagePackSerializerOptions, ct);
        }

        public async ValueTask<HttpContent> CreateContentAsync<T>(T @object, MediaTypeHeaderValue mediaType = null, CancellationToken ct = default)
        {
            mediaType ??= mediaTypeHeaderValue;
            var stream = new MemoryStream();

            await MessagePackSerializer.SerializeAsync(stream, @object, SerializerOptions.Value.MessagePackSerializerOptions, default);

            var content = new StreamContent(stream);
            content.Headers.ContentType = mediaType;

            return content;
        } 

        #endregion
    }
}
