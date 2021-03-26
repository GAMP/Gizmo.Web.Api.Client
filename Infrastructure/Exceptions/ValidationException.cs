using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace Gizmo.Web.Api.Client
{
    /// <summary>
    /// Validation exception.
    /// </summary>
    public class ValidationException : WebApiClientException
    {
        #region CONSTRUCTOR
        public ValidationException(HttpStatusCode httpStatusCode, string errorMessage, string errorCodeType, int? errorCode, IEnumerable<WebApiError> errors) : base(httpStatusCode, errorMessage, errorCodeType, errorCode)
        {
            HttpStatusCode = httpStatusCode;
            Errors = errors;
        }

        #endregion

        #region PROPERTIES

        public IEnumerable<WebApiError> Errors
        {
            get;
            protected set;
        }

        #endregion
    }
}