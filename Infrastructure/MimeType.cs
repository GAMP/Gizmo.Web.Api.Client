namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Media types.
    /// </summary>
    /// <remarks>
    /// This will be used until we switch to .net std 2.1 or .net 5 since those enumeration exist there.
    /// </remarks>
    public static class MimeType
    {
        #region CONSTANTS
        
        public const string JSON = "application/json";
        
        public const string MSGPACK = "application/x-msgpack"; 

        #endregion
    }
}
