using System.Text.Json;

namespace Gizmo.Web.Api.Client
{
    /// <summary>
    /// Json payload serializer options.
    /// </summary>
    public class JsonPayloadSerializerOptions
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
