using System;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Web api route attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class WebApiRouteAttribute : Attribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="route">Web api relative route.</param>
        public WebApiRouteAttribute(string route)
        {
            if (string.IsNullOrWhiteSpace(route))
                throw new ArgumentNullException(nameof(route));

            Route = route;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets route.
        /// </summary>
        public string Route
        {
            get; private set;
        }

        #endregion
    }
}
