using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Json payload serializer.
    /// </summary>
    internal class JsonPayloadSerializer : IPayloadSerializer
    {
        #region CONSTRUCTOR
        public JsonPayloadSerializer(IOptions<JsonPayloadSerializerOptions> options)
        {
            SerializerOptions = options;
        }
        #endregion

        #region FIELDS

        private static readonly MediaTypeHeaderValue MediaTypeHeaderValue = new(MimeType.JSON);

        #endregion

        #region PROPERTIES

        public string Name => "json";

        private IOptions<JsonPayloadSerializerOptions> SerializerOptions
        {
            get; set;
        }

        public string DefaultAcceptHeader => MimeType.JSON;

        #endregion

        #region IPayloadSerializer

        public ValueTask<T> DeserializeAsync<T>(Stream stream, CancellationToken ct)
        {
            return JsonSerializer.DeserializeAsync<T>(stream, SerializerOptions.Value.JsonSerializerOptions, ct);
        }

        public async ValueTask<HttpContent> CreateContentAsync<T>(T data, MediaTypeHeaderValue? mediaType = null, CancellationToken ct = default)
        {
            //use default media type if one not specified
            mediaType ??= MediaTypeHeaderValue;

            //create memory stream
            var stream = new MemoryStream();

            //serialize object to the memory stream
            await JsonSerializer.SerializeAsync(stream, data, SerializerOptions.Value.JsonSerializerOptions, ct);

            //rewind the stream
            stream.Seek(0, SeekOrigin.Begin);

            //create stream content from serialized stream
            var httpContent = new StreamContent(stream);

            //set content type header
            httpContent.Headers.ContentType = mediaType;

            //return newly created http content
            return httpContent;
        }

        #endregion
    }
}
