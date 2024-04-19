using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Delegating handler that adds current culture to the http requests.
    /// </summary>
    public sealed class CurrentUICultureDelegatingHandler : DelegatingHandler
    {
        protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            AddHeaders(request);
            return base.Send(request, cancellationToken);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            AddHeaders(request);
            return base.SendAsync(request, cancellationToken);
        }

        private static void AddHeaders(HttpRequestMessage request)
        {
            if (request.Headers.AcceptLanguage.Count == 0)
                request.Headers.AcceptLanguage.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue(CultureInfo.CurrentUICulture.ToString()));
        }
    }
}
