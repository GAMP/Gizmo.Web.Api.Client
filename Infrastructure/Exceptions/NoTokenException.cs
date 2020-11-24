using System;

namespace Gizmo.Web.Api.Client
{
    /// <summary>
    /// Exception to represent state where its impossible to obtain authentication token.
    /// </summary>
    public class NoTokenException :Exception
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public NoTokenException() { } 
        #endregion
    }
}
