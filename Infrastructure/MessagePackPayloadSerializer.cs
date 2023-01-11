using MessagePack;
using Microsoft.Extensions.Options;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
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

        public string DefaultAcceptHeader => MimeType.MSGPACK;

        #endregion

        #region IPayloadSerializer

        public ValueTask<T> DeserializeAsync<T>(Stream stream, CancellationToken ct)
        {
            return MessagePackSerializer.DeserializeAsync<T>(stream, SerializerOptions.Value.MessagePackSerializerOptions, ct);
        }

        public async ValueTask<HttpContent> CreateContentAsync<T>(T @object, MediaTypeHeaderValue mediaType = null, CancellationToken ct = default)
        {
            //use default media type if one not specified
            mediaType ??= mediaTypeHeaderValue;
            
            //create memory stream
            var stream = new MemoryStream();

            //serialize object to the memory stream
            await MessagePackSerializer.SerializeAsync(stream, @object, SerializerOptions.Value.MessagePackSerializerOptions, default);
            
            //rewind the stream
            stream.Seek(0, SeekOrigin.Begin);

            //create stream content from serialized stream
            var content = new StreamContent(stream);

            //set content type header
            content.Headers.ContentType = mediaType;

            //return newly created http content
            return content;
        } 

        #endregion
    }
}
