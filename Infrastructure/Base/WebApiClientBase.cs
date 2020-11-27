using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Json;
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
        /// Gets current host path.
        /// </summary>
        /// <returns></returns>
        protected virtual string GetRequestHostPath()
        {
            return HttpClient.BaseAddress.AbsoluteUri;
        }

        /// <summary>
        /// Returns base api endpoint request path.
        /// </summary>
        /// <returns>Base api endpoint path, for example api/sessions.</returns>
        protected virtual string GetRequestRoutePath()
        {
            var routeAttribute = GetType().GetCustomAttribute<WebApiRouteAttribute>();
            if (routeAttribute == null)
                throw new ArgumentNullException("Route attribute is not specified for the client.", nameof(routeAttribute));

            return routeAttribute.Route;
        }

        protected virtual string CreateRequestUrlWithRouteParameters(string routeParameters)
        {
            return CreateRequestUrl(routeParameters, null);
        }

        protected virtual string CreateRequestUrlWithQueryParameters(string queryParameters)
        {
            return CreateRequestUrl(null, queryParameters);
        }

        protected virtual string CreateRequestUrl(IUrlRouteParameters routeParameters)
        {
            return CreateRequestUrl(routeParameters, null);
        }

        protected virtual string CreateRequestUrl(IUrlQueryParameters queryParameters)
        {
            return CreateRequestUrl(null, queryParameters);
        }

        protected virtual string CreateRequestUrl(IUrlRouteParameters routeParameters, IUrlQueryParameters queryParameters)
        {
            return CreateRequestUrl(ParameterGenerator.Generate(routeParameters),ParameterGenerator.Generate(queryParameters));
        }

        public virtual string CreateRequestUrl()
        {
            return CreateRequestUrl(default(string), default(string));
        }

        /// <summary>
        /// Creates full request url based on specified parameters.
        /// </summary>
        /// <param name="routeParameters">Optional route parameters.</param>
        /// <param name="queryParameters">Optional query parameters.</param>
        /// <returns>Full request url.</returns>
        protected virtual string CreateRequestUrl(string routeParameters, string queryParameters)
        {
            //get our host path
            var host = GetRequestHostPath();

            //get base route path
            var routePath = GetRequestRoutePath();

            //check if any route parameters specified
            if (!string.IsNullOrWhiteSpace(routeParameters))
                routePath = $"{routePath}/{routeParameters}";

            //use uri builder to create full request url
            //this can be done manually
            return new UriBuilder(host) { Path = routePath, Query = queryParameters, }.ToString();
        }

        #endregion

        #region PRIVATE FUNCTIONS

        /// <summary>
        /// Awaits the spcified web api http function and returns its result.
        /// </summary>
        /// <typeparam name="TResult">Result type.</typeparam>
        /// <param name="task">Web api http function task.</param>
        /// <returns>Function result.</returns>
        private async Task<TResult> AwaitWebApiResultAsync<TResult>(Task<WebApiResponse<TResult>> task)
        {
            var webApiResult = await task;
            return webApiResult.Result;
        }

        #endregion

        #region PROTECTED VIRTUAL     

        #region GET
        
        protected Task<TResult> GetAsync<TResult>(IUrlParameters parameters, CancellationToken ct)
        {
            return GetAsync<TResult>(CreateRequestUrl(parameters as IUrlRouteParameters, parameters as IUrlQueryParameters), ct);
        }

        protected Task<TResult> GetAsync<TResult>(string requestUri, CancellationToken ct = default)
        {
            return AwaitWebApiResultAsync(GetWebApiResultAsync<TResult>(requestUri, ct));
        }

        protected Task<WebApiResponse<TResult>> GetWebApiResultAsync<TResult>(string requestUri, CancellationToken ct = default)
        {
            return GetResultAsync<WebApiResponse<TResult>>(requestUri, ct);
        }

        protected async Task<TResult> GetResultAsync<TResult>(string requestUri, CancellationToken ct = default)
        {
            using (var httpMessage = CreateHttpRequestMessage(requestUri, HttpMethod.Get))
            {
                using (var responseMessage = await HttpClient.SendAsync(httpMessage, HttpCompletionOption.ResponseHeadersRead, ct).ConfigureAwait(false))
                {
                    return await GetHttpMessageResultAsync<TResult>(responseMessage, ct);
                }
            }
        }

        #endregion

        #region PUT

        protected Task<TResult> PutAsync<TResult>(IUrlParameters parameters, object content, CancellationToken ct = default)
        {
            return PutAsync<TResult>(CreateRequestUrl(parameters as IUrlRouteParameters, parameters as IUrlQueryParameters), content, ct);
        }

        protected async Task<TResult> PutAsync<TResult>(string requestUri, object content, CancellationToken ct = default)
        {
            using (var httpContent = await CreateContentAsync(content, ct))
            {
                return await AwaitWebApiResultAsync(PutWebApiResultAsync<TResult>(requestUri, httpContent, ct));
            }
        }

        protected Task<TResult> PutAsync<TResult>(string requestUri, HttpContent content, CancellationToken ct = default)
        {
            return AwaitWebApiResultAsync(PutWebApiResultAsync<TResult>(requestUri, content, ct));
        }

        protected Task<WebApiResponse<TResult>> PutWebApiResultAsync<TResult>(string requestUri, HttpContent content, CancellationToken ct = default)
        {
            return PutResultAsync<WebApiResponse<TResult>>(requestUri, content, ct);
        }

        protected async Task<TResult> PutResultAsync<TResult>(string requestUri, HttpContent content, CancellationToken ct = default)
        {
            using (var httpMessage = CreateHttpRequestMessage(requestUri, HttpMethod.Put, content))
            {
                using (var responseMessage = await HttpClient.SendAsync(httpMessage, HttpCompletionOption.ResponseHeadersRead, ct).ConfigureAwait(false))
                {
                    return await GetHttpMessageResultAsync<TResult>(responseMessage, ct);
                }
            }
        }

        #endregion

        #region POST

        protected Task<TResult> PostAsync<TResult>(IUrlParameters parameters, object content, CancellationToken ct = default)
        {
            return PostAsync<TResult>(CreateRequestUrl(parameters as IUrlRouteParameters, parameters as IUrlQueryParameters), content, ct);
        }

        protected async Task<TResult> PostAsync<TResult>(string requestUri, object content, CancellationToken ct = default)
        {
            using (var httpContent = await CreateContentAsync(content, ct))
            {
                return await AwaitWebApiResultAsync(PostWebApiResultAsync<TResult>(requestUri, httpContent, ct));
            }
        }

        protected Task<TResult> PostAsync<TResult>(string requestUri, HttpContent content, CancellationToken ct = default)
        {
            return AwaitWebApiResultAsync(PostWebApiResultAsync<TResult>(requestUri, content, ct));
        }

        protected Task<WebApiResponse<TResult>> PostWebApiResultAsync<TResult>(string requestUri, HttpContent content, CancellationToken ct = default)
        {
            return PostResultAsync<WebApiResponse<TResult>>(requestUri, content, ct);
        }

        protected async Task<TResult> PostResultAsync<TResult>(string requestUri, HttpContent content, CancellationToken ct = default)
        {
            using (var httpMessage = CreateHttpRequestMessage(requestUri, HttpMethod.Post, content))
            {
                using (var responseMessage = await HttpClient.SendAsync(httpMessage, HttpCompletionOption.ResponseHeadersRead, ct).ConfigureAwait(false))
                {
                    return await GetHttpMessageResultAsync<TResult>(responseMessage, ct);
                }
            }
        }

        #endregion

        #region DELETE

        protected Task<TResult> DeleteAsync<TResult>(string requestUri, CancellationToken ct = default)
        {
            return AwaitWebApiResultAsync(DeleteWebApiResultAsync<TResult>(requestUri, ct));
        }

        protected Task<WebApiResponse<TResult>> DeleteWebApiResultAsync<TResult>(string requestUri, CancellationToken ct = default)
        {
            return DeleteResultAsync<WebApiResponse<TResult>>(requestUri, ct);
        }

        protected async Task<TResult> DeleteResultAsync<TResult>(string requestUri, CancellationToken ct = default)
        {
            using (var httpMessage = CreateHttpRequestMessage(requestUri, HttpMethod.Delete))
            {
                using (var responseMessage = await HttpClient.SendAsync(httpMessage, HttpCompletionOption.ResponseHeadersRead, ct).ConfigureAwait(false))
                {
                    return await GetHttpMessageResultAsync<TResult>(responseMessage, ct);
                }
            }
        }

        #endregion

        protected async Task<TResult> GetHttpMessageResultAsync<TResult>(HttpResponseMessage httpResponseMessage, CancellationToken ct = default)
        {
            if (httpResponseMessage == null)
                throw new ArgumentNullException(nameof(httpResponseMessage));
          
            await ThrowApiExceptionIfRequiredAsync(httpResponseMessage, ct);

            using (var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync())
            {
                //get our content headers
                var contentHeaders = httpResponseMessage.Content.Headers;
                switch(contentHeaders.ContentType.MediaType)
                {
                    case MimeType.JSON:
                        break;
                    case MimeType.MSGPACK:
                        break;
                    default:
                        break;
                }

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
        protected async Task ThrowApiExceptionIfRequiredAsync(HttpResponseMessage httpResponseMessage, CancellationToken ct)
        {
            //check status code
            switch (httpResponseMessage.StatusCode)
            {
                //allow notmal response message processing in case of OK status code.
                case System.Net.HttpStatusCode.OK:
                    return;
            }

            //get content stream
            using (var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync())
            {
                var options = new JsonSerializerOptions
                {
                    AllowTrailingCommas = true,
                    PropertyNameCaseInsensitive = true,
                };

                //deserialize error response
                var errorResponse = await JsonSerializer.DeserializeAsync<WebApiErrorResponse>(contentStream, options, ct);

                //throw appropriate exception
                throw new HTTPAPIException(httpResponseMessage.StatusCode, httpResponseMessage.ReasonPhrase, errorResponse.ErrorCode);
            }
        }

        /// <summary>
        /// Creates http request message.
        /// </summary>
        /// <param name="requestUrl">Request url.</param>
        /// <param name="method">Request method.</param>
        /// <param name="content">Optional request http content.</param>
        /// <returns>Http request message.</returns>
        protected HttpRequestMessage CreateHttpRequestMessage(string requestUrl, HttpMethod method, HttpContent content=default)
        {
            return new HttpRequestMessage(method, requestUrl) {  Content = content };
        }

        /// <summary>
        /// Creates appropriate Http Content based on current client options.
        /// </summary>
        /// <param name="obj">Content object.</param>
        /// <returns>HttpContent.</returns>
        protected ValueTask<HttpContent> CreateContentAsync(object obj,CancellationToken ct)
        {
            if (obj == null)
                return new ValueTask<HttpContent>();
            
            //serializaer based configuration goes here 

            return new ValueTask<HttpContent>(JsonContent.Create(obj));         
        }

        #endregion

        #region Validation

        /// <summary>
        /// Validates the state of current object and 
        /// </summary>
        /// <param name="obj"><Content object/param>
        /// <returns> List of errors</returns>
        protected List<ValidationResult> Validate(object obj)
        {
            var ctx = new ValidationContext(obj);
            var results = new List<ValidationResult>();
            if(!Validator.TryValidateObject(obj, ctx, results, true))
            {
                return results;
            }
            return null;
        }
        #endregion
    }
}
