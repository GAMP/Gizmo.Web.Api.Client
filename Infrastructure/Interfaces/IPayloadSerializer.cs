using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    /// <summary>
    /// Payload serializer interface.
    /// </summary>
    public interface IPayloadSerializer
    {
        #region PROPERTIES

        /// <summary>
        /// Gets serializer name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets default accept header for outgoing requests.
        /// </summary>
        string DefaultAcceptHeader { get; }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Deserialize stream to specified type.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="stream">Payload stream.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Deserialized object.</returns>
        ValueTask<T> DeserializeAsync<T>(Stream stream, CancellationToken ct = default);

        /// <summary>
        /// Creates Http Content object.
        /// </summary>
        /// <typeparam name="T">Content object type.</typeparam>
        /// <param name="object">Content object.</param>
        /// <param name="mediaType">Optional media type header value.</param>
        /// <returns>HttpContent.</returns>
        ValueTask<HttpContent> CreateContentAsync<T>(T @object, MediaTypeHeaderValue mediaType = null,CancellationToken ct=default);

        #endregion
    }
}
