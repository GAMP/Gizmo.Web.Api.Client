using Microsoft.Extensions.DependencyInjection;

namespace Gizmo.Web.Api.Client
{
    /// <summary>
    /// Blazor host extensions.
    /// </summary>
    public static class BlazorHostExtensions
    {
        /// <summary>
        /// Adds web api clients to service collection.
        /// </summary>
        /// <param name="services">Service collection.</param>
        public static void AddWebApiClient(this IServiceCollection services)
        {
            services.AddSingleton<UsersWebApiClient>();
            services.AddSingleton<ProductsWebApiClient>();
        }
    }
}
