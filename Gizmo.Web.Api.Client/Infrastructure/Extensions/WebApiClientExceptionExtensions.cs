using System;
using Gizmo.Server.Exceptions;

namespace Gizmo.Web.Api.Clients
{
    public static class WebApiClientExceptionExtensions
    {
        /// <summary>
        /// Checks for specific exception code.
        /// </summary>
        /// <param name="exception">Exception instance.</param>
        /// <param name="exceptionCode">Exception code.</param>
        /// <returns>True or false.</returns>
        public static bool IsExceptionCode(this Exception exception, ExceptionCode exceptionCode) => IsExceptionCode<ExceptionCode>(exception, exceptionCode, null);

        /// <summary>
        /// Checks for specific exception and extended code.
        /// </summary>
        /// <param name="exception">Exception instance.</param>
        /// <param name="exceptionCode">Exception code.</param>
        /// <param name="codeValue">Extended code.</param>
        /// <returns>True or false.</returns>
        public static bool IsExceptionCode(this Exception exception, ExceptionCode exceptionCode, Enum codeValue) => IsExceptionCode<ExceptionCode>(exception, exceptionCode, codeValue);

        public static bool IsExceptionCode<TExceptionCode>(this Exception exception, TExceptionCode exceptionCode, Enum? codeValue = null)
            where TExceptionCode : Enum
        {
            // must be web api client exception
            if (exception is not WebApiClientException webApiClientException)
                return false;

            // must contain error code type
            if (webApiClientException.ErrorCodeType == null)
                return false;

            if (codeValue != null)
            {
                // we require error code but exception does not provide one
                if (webApiClientException.ErrorCode == null)
                    return false;

                // check if codes match
                if (webApiClientException.ErrorCode != Convert.ToInt64(codeValue))
                    return false;
            }

            return Convert.ToInt64(webApiClientException.ErrorCodeType.Value) == Convert.ToInt64(exceptionCode);
        }
    }
}
