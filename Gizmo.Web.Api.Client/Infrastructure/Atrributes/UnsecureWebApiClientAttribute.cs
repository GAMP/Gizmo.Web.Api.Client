using System;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Attribute used for clients that do not require authorozation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class UnsecureWebApiClientAttribute : Attribute
    {
    }
}
