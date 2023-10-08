using System;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Exception to represent state where its impossible to obtain authentication token.
    /// </summary>
    public sealed class NoTokenException : Exception
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public NoTokenException() { }

        public NoTokenException(string message) : base(message)
        {
        }

        public NoTokenException(string message, Exception innerException) : base(message, innerException)
        {
        }
        #endregion
    }
}
