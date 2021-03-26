using System;
using System.Net;

namespace Gizmo.Web.Api.Client
{
    /// <summary>
    /// Generic web api exception.
    /// </summary>
    public class WebApiClientException : Exception
    {
        #region CONSTRUCTOR
        public WebApiClientException(HttpStatusCode httpStatusCode, string errorMessage, string errorCodeType, int? errorCode) : base(errorMessage)
        {
            HttpStatusCode = httpStatusCode;
            ErrorCodeType = errorCodeType;
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

        public string ErrorCodeType
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