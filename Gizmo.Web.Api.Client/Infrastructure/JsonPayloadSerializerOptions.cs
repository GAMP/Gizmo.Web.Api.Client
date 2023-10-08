using System.Text.Json;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Json payload serializer options.
    /// </summary>
    public sealed class JsonPayloadSerializerOptions
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets or sets json serialization options.
        /// </summary>
        public JsonSerializerOptions JsonSerializerOptions
        {
            get;
            set;
        } = new JsonSerializerOptions(); 

        #endregion
    }
}
