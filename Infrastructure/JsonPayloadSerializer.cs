using Microsoft.Extensions.Options;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
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

        private static readonly MediaTypeHeaderValue mediaTypeHeaderValue = new(MimeType.JSON);

        #endregion

        #region PROPERTIES

        public string Name => "json";

        private IOptions<JsonPayloadSerializerOptions> SerializerOptions
        {
            get; set;
        }

        #endregion

        #region IPayloadSerializer
        
        public ValueTask<T> DeserializeAsync<T>(Stream stream, CancellationToken ct)
        {
            return JsonSerializer.DeserializeAsync<T>(stream, SerializerOptions.Value.JsonSerializerOptions, ct);
        }

        public async ValueTask<HttpContent> CreateContentAsync<T>(T @object, MediaTypeHeaderValue mediaType = null, CancellationToken ct = default)
        {
            mediaType ??= mediaTypeHeaderValue;
            var stream = new MemoryStream();

            await JsonSerializer.SerializeAsync(stream, @object, SerializerOptions.Value.JsonSerializerOptions, ct);
            var content = new StreamContent(stream);
            content.Headers.ContentType = mediaType;

            return content;
        } 

        #endregion
    }
}
