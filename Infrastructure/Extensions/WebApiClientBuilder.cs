using Microsoft.Extensions.DependencyInjection;

namespace Gizmo.Web.Api.Client.Builder
{
    internal class WebApiClientBuilder : IWebApiClientBuilder
    {
        public WebApiClientBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
