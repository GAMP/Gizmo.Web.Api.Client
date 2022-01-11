using Microsoft.Extensions.DependencyInjection;

namespace Gizmo.Web.Api.Client.Builder
{
    /// <summary>
    /// Web api client builder.
    /// </summary>
    internal class WebApiClientBuilder : IWebApiClientBuilder
    {
        #region CONSTRCUTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="services">Services collection.</param>
        public WebApiClientBuilder(IServiceCollection services)
        {
            Services = services;
        }

        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Gets services collection.
        /// </summary>
        public IServiceCollection Services { get; } 

        #endregion
    }
}
