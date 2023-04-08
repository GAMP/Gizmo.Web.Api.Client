using Gizmo.Web.Api.Models.Abstractions;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Token auth endpoint uri parameters.
    /// </summary>
    public sealed class TokenParameters : IUriParametersQuery
    {
        public string Username { get; init; } = null!;
        public string Password { get; init; } = null!;
        public bool UserToken { get; init; } = false;
    }
}
