namespace Gizmo.Web.Api.Client
{
    /// <summary>
    /// Payload serializer provider.
    /// </summary>
    public interface IPayloadSerializerProvider
    {
        #region FUNCTIONS

        /// <summary>
        /// Gets payload serializer.
        /// </summary>
        /// <param name="name">Payload serializer name.</param>
        /// <returns>Payload serializer, null if serializer specified by <paramref name="name"/> not found.</returns>
        IPayloadSerializer GetSerializer(string name);

        /// <summary>
        /// Gets default serializer.
        /// </summary>
        /// <returns>Current default serializer.</returns>
        IPayloadSerializer DefaultSerializer { get; }

        #endregion
    }
}
