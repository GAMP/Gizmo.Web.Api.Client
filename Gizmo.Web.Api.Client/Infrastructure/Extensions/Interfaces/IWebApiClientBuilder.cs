using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

namespace Gizmo.Web.Api.Clients.Builder
{
    public interface IWebApiClientBuilder
    {
        IServiceCollection Services { get; }
        IEnumerable<IHttpClientBuilder> HttpClientBuilders { get; }
    }
}
