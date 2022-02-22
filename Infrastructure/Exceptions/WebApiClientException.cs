using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace Gizmo.Web.Api.Client
{
    /// <summary>
    /// Generic web api exception.
    /// </summary>
    public class WebApiClientException : Exception
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="httpStatusCode">Http status code.</param>
        /// <param name="errorMessage">Error message.</param>
        public WebApiClientException(HttpStatusCode httpStatusCode, string errorMessage) : this(httpStatusCode, errorMessage, null, null, null, null)
        {

        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="httpStatusCode">Http status code.</param>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="errorCodeType">Error code type.</param>
        /// <param name="errorCodeTypeReadable">Error code type in human readable form.</param>
        /// <param name="errorCode">Error code.</param>
        /// <param name="errorCodeReadable">Error code in human readable form.</param>
        public WebApiClientException(HttpStatusCode httpStatusCode,
            string errorMessage,
            int? errorCodeType,
            string errorCodeTypeReadable,
            int? errorCode,
            string errorCodeReadable,
            IEnumerable<WebApiErrorBase> errors =default) : base(errorMessage)
        {
            HttpStatusCode = httpStatusCode;
            ErrorCodeType = errorCodeType;
            ErrorCodeTypeReadable = errorCodeTypeReadable;
            ErrorCode = errorCode;
            ErrorCodeRedable = errorCodeReadable;
            Errors = errors;
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
        /// Gets error code type.
        /// </summary>
        public int? ErrorCodeType
        {
            get; protected set;
        }

        /// <summary>
        /// Error code type in human readable form.
        /// </summary>
        public string ErrorCodeTypeReadable
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

        /// <summary>
        /// Error code in human readable form.
        /// </summary>
        public string ErrorCodeRedable
        {
            get; protected set;
        }

        /// <summary>
        /// Gets extended error collection.
        /// </summary>
        public IEnumerable<WebApiErrorBase> Errors
        {
            get;protected set;
        }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Checks error code type equality.
        /// </summary>
        /// <param name="errorCodeType">Error code type.</param>
        /// <returns>True or false.</returns>
        public bool IsErrorCodeType(Enum errorCodeType)
        {
            //we dont have error code type which means type will never match
            if (ErrorCodeType == null)
                return false;

            //specified enum value is not defined
            if (!Enum.IsDefined(errorCodeType.GetType(), errorCodeType))
                return false;

            return ErrorCodeType == Convert.ToInt32(errorCodeType);
        }

        /// <summary>
        /// Checks error code equality.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        /// <returns>True or false.</returns>
        public bool IsErrorCode(Enum errorCode)
        {
            //we dont have error code which means type will never match
            if (ErrorCode == null)
                return false;

            //specified enum value is not defined
            if (!Enum.IsDefined(errorCode.GetType(), errorCode))
                return false;

            //since its value type we should be able to use equals to compare the values
            return ErrorCode == Convert.ToInt32(errorCode);
        }

        /// <summary>
        /// Checks error code type and error code equality.
        /// </summary>
        /// <param name="errorCodeType">Error code type.</param>
        /// <param name="errorCode">Error code.</param>
        /// <returns></returns>
        public bool IsError(Enum errorCodeType, Enum errorCode)
        {
            return IsErrorCodeType(errorCodeType) && IsErrorCode(errorCode);
        }

        /// <summary>
        /// Checks http status code equality.
        /// </summary>
        /// <param name="httpStatusCode">HTTP Status code.</param>
        /// <returns>True or false.</returns>
        public bool IsHttpStatusCode(HttpStatusCode httpStatusCode)
        {
            return HttpStatusCode == httpStatusCode;
        }

        #endregion
    }
}