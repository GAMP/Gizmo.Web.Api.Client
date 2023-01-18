using Microsoft.Extensions.DependencyInjection;

namespace Gizmo.Web.Api.Clients.Builder
{
    public interface IWebApiClientBuilder
    {
        IServiceCollection Services { get; }
    }
}
