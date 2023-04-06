using Microsoft.Extensions.DependencyInjection;

namespace Gizmo.Web.Api.Clients.Builder
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
        public WebApiClientBuilder(IServiceCollection services, string clientName)
        {
            Services = services;
            Name = clientName;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets services collection.
        /// </summary>
        public IServiceCollection Services { get; }

        /// <summary>
        /// Gets client name.
        /// </summary>
        public string Name { get; }

        #endregion
    }
}
