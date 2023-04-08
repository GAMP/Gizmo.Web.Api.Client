using Gizmo.Web.Api.Models.Abstractions;

namespace Gizmo.Web.Api.Clients
{ 
    /// <summary>
    /// Refresh token auth endpoint uri parameters.
    /// </summary>
    public sealed class RefreshTokenParameters : IUriParametersQuery
    {
        public string Token { get; init; } = null!;
        public string RefreshToken { get; init; } = null!;
    }
}
