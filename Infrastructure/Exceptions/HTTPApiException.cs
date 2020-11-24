using System;
using System.Net;

namespace Gizmo.Web.Api.Client
{
    /// <summary>
    /// Generic http api exception.
    /// </summary>
    public class HTTPAPIException :Exception
    {
        #region CONSTRUCTOR
        public HTTPAPIException(HttpStatusCode httpStatusCode, string errorMessage, int? errorCode) : base(errorMessage)
        {
            HttpStatusCode = httpStatusCode;
            ErrorCode = errorCode;
        } 
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets http status code.
        /// </summary>
        public HttpStatusCode HttpStatusCode
        {
            get; protected set;
        }

        /// <summary>
        /// Gets api error code.
        /// </summary>
        public int? ErrorCode
        {
            get; protected set;
        } 

        #endregion
    }
}
