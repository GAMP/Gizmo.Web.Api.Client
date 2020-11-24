using Gizmo.Web.Api.Models;
using System;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    /// <summary>
    /// Base web api client implementation.
    /// </summary>
    public abstract class WebApiClientBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="httpClient">Http client instance.</param>
        public WebApiClientBase(HttpClient httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets associated http client.
        /// </summary>
        public HttpClient HttpClient { get; }

        #endregion

        #region ABSTRACT

        /// <summary>
        /// Returns base api endpoint request path.
        /// </summary>
        /// <returns>Base api endpoint path, for example api/sessions.</returns>
        protected virtual string GetEndpointPath()
        {
          var routeAttribute =  GetType().GetCustomAttribute<WebApiRouteAttribute>();
            if (routeAttribute == null)
                throw new ArgumentNullException("Route attribute is not specified for the client.", nameof(routeAttribute));

            return routeAttribute.Route;
        }

        #endregion

        #region PROTECTED VIRTUAL

        /// <summary>
        /// Gets base service host url.
        /// </summary>
        /// <returns>Base service host url.</returns>
        /// <remarks>
        /// While in debug build default service url is returned.
        /// </remarks>
        protected virtual Uri GetBaseUri()
        {
            //#if DEBUG
            //            return new Uri(@"http://localhost:80");
            //#else
            //            var baseUri = new Uri(UriHelper.BaseUri);
            //            return new UriBuilder(baseUri).Uri;
            //#endif
            return new Uri(@"http://localhost:80");
        }

        protected virtual Uri GetRequestBasePath()
        {
            var baseUri = GetBaseUri();
            var endpointUri = GetEndpointPath();
            var fullEndpointUri = new UriBuilder(baseUri) { Path = endpointUri };
            return fullEndpointUri.Uri;
        }

        protected virtual Uri GetRequestUri(string function)
        {
            return GetRequestUri(function, null);
        }

        protected virtual Uri GetRequestUri(string function, string query)
        {
            var requestBasePath = GetRequestBasePath();

            var requestFullUri = !string.IsNullOrWhiteSpace(function) ? new Uri(requestBasePath, function) : requestBasePath;

            var fullUri = new UriBuilder(requestFullUri) { Query = query };

            return fullUri.Uri;
        }

        protected async Task<WebApiResponse<TResult>> GetApiResultResponseAsync<TResult>(string endpoint, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(endpoint))
                throw new ArgumentNullException(nameof(endpoint));

            using (var responseMessage = await HttpClient.GetAsync(endpoint, ct))
            {
                return await GetApiResultResponseAsync<TResult>(responseMessage, ct);
            }
        }

        protected Task<WebApiResponse<TResult>> GetApiResultResponseAsync<TResult>(HttpResponseMessage httpResponseMessage, CancellationToken ct = default)
        {
            return GetApiResponseAsync<WebApiResponse<TResult>>(httpResponseMessage, ct);
        }

        protected async Task<TResult> GetApiResponseAsync<TResult>(HttpResponseMessage httpResponseMessage, CancellationToken ct = default)
        {
            if (httpResponseMessage == null)
                throw new ArgumentNullException(nameof(httpResponseMessage));

            ThrowApiException(httpResponseMessage);

            using (var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync())
            {
                var options = new JsonSerializerOptions
                {
                    AllowTrailingCommas = true,
                    PropertyNameCaseInsensitive = true,
                };
                return await JsonSerializer.DeserializeAsync<TResult>(contentStream, options, ct);
            }
        }

        /// <summary>
        /// Throws http api exception in case exception code is not 200.
        /// </summary>
        /// <param name="httpResponseMessage">Http response message.</param>
        protected void ThrowApiException(HttpResponseMessage httpResponseMessage)
        {
            switch (httpResponseMessage.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    break;
                default:
                    throw new HTTPAPIException(httpResponseMessage.StatusCode, httpResponseMessage.ReasonPhrase, null);
            }
        }

        #endregion
    }
}
