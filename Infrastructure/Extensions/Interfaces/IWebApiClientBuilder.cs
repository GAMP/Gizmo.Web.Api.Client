using Microsoft.Extensions.DependencyInjection;

namespace Gizmo.Web.Api.Client.Builder
{
    public interface IWebApiClientBuilder
    {
        IServiceCollection Services { get; }
    }
}
