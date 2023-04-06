using System.Collections.Generic;

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
        public WebApiClientBuilder(IServiceCollection services, IEnumerable<IHttpClientBuilder> httpClientBuilders)
        {
            Services = services;
            HttpClientBuilders = httpClientBuilders;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets services collection.
        /// </summary>
        public IServiceCollection Services { get; }

        /// <summary>
        /// Gets http client builders.
        /// </summary>
        public IEnumerable<IHttpClientBuilder> HttpClientBuilders { get; }

        #endregion
    }
}
