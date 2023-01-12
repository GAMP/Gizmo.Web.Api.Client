using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Abstractions.Models.RequestParameters;

using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
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
        /// <param name="options">Web api client options.</param>
        /// <param name="payloadSerializerProvider">Payload serializer.</param>
        public WebApiClientBase(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            SerializerProvider = payloadSerializerProvider;
            Serializer = SerializerProvider.DefaultSerializer;
            Options = options;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets associated http client.
        /// </summary>
        public HttpClient HttpClient { get; }

        /// <summary>
        /// Gets web client options.
        /// </summary>
        public IOptions<WebApiClientOptions> Options { get; }

        /// <summary>
        /// Gets payload serializer provider.
        /// </summary>
        private IPayloadSerializerProvider SerializerProvider { get; set; }

        /// <summary>
        /// Gets current payload serializer.
        /// </summary>
        private IPayloadSerializer Serializer { get; set; }

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
            
            return routeAttribute == null
                ? throw new ArgumentNullException("Route attribute is not specified for the client.", nameof(routeAttribute))
                : routeAttribute.Route;
        }

        protected virtual string CreateRequestUrlWithRouteParameters(string routeParameters)
        {
            return CreateRequestUrl(routeParameters, default(IUrlQueryParameters));
        }
       
        protected virtual string CreateRequestUrl(string routeParameters, IUrlQueryParameters queryParameters)
        {
            return CreateRequestUrl(routeParameters, ParameterGenerator.Generate(queryParameters));
        }

        protected virtual Uri CreateRequestUri(IRequestParameters requestParameters)
        {
            var routeAttribute = GetType().GetCustomAttribute<WebApiRouteAttribute>();
            
            if (routeAttribute == null)
                throw new ArgumentNullException("Route attribute is not specified for the client.", nameof(routeAttribute));

            var uriBuilder = new UriBuilder(HttpClient.BaseAddress.AbsoluteUri);

            if (requestParameters.Query != null)
                uriBuilder.Query = requestParameters.Query;

            uriBuilder.Path = requestParameters.Path != null
                ? routeAttribute.Route + '/' + requestParameters.Path
                : routeAttribute.Route;

            return uriBuilder.Uri;
        }

        public virtual string CreateRequestUrl()
        {
            return CreateRequestUrl(default, default(string));
        }

        /// <summary>
        /// Creates full request url based on specified parameters.
        /// </summary>
        /// <param name="routeParameters">Optional route parameters.</param>
        /// <param name="queryParameters">Optional query parameters.</param>
        /// <returns>Full request url.</returns>
        protected virtual string CreateRequestUrl(string routeParameters, string queryParameters)
        {
            //get http client host path
            var hostPath = GetRequestHostPath();

            //get base route path
            var routePath = GetRequestRoutePath();

            //check if any route parameters specified
            if (!string.IsNullOrWhiteSpace(routeParameters))
                routePath = $"{routePath}/{routeParameters}";

            //use uri builder to create full request url
            //this can be done manually
            return new UriBuilder(hostPath) { Path = routePath, Query = queryParameters, }.ToString();
        }

        #endregion

        #region HTTP METHODS

        #region GET
        protected async Task<TResult> GetAsync<TResult>(IRequestParameters parameters, CancellationToken ct)
        {
            var uri = CreateRequestUri(parameters);

            var response = await GetResultAsync<WebApiResponse<TResult>>(uri, ct);

            return response.Result;
        }
        private async Task<TResult> GetResultAsync<TResult>(Uri uri, CancellationToken ct = default)
        {
            using (var httpMessage = CreateHttpRequestMessage(uri, HttpMethod.Get))
            {
                using (var responseMessage = await HttpClient.SendAsync(httpMessage, HttpCompletionOption.ResponseHeadersRead, ct).ConfigureAwait(false))
                {
                    return await GetHttpMessageResultAsync<TResult>(responseMessage, ct);
                }
            }
        }
        #endregion

        #region PUT
        protected async Task<TResult> PutAsync<TResult>(IRequestParameters parameters, object content, CancellationToken ct = default)
        {
            var uri = CreateRequestUri(parameters);

            using (var httpContent = await CreateContentAsync(content, ct))
            {
                var response = await PutResultAsync<WebApiResponse<TResult>>(uri, httpContent, ct);
                
                return response.Result;
            }
        }
        private async Task<TResult> PutResultAsync<TResult>(Uri uri, HttpContent content, CancellationToken ct = default)
        {
            using (var httpMessage = CreateHttpRequestMessage(uri, HttpMethod.Put, content))
            {
                using (var responseMessage = await HttpClient.SendAsync(httpMessage, HttpCompletionOption.ResponseHeadersRead, ct).ConfigureAwait(false))
                {
                    return await GetHttpMessageResultAsync<TResult>(responseMessage, ct);
                }
            }
        }
        #endregion

        #region POST
        protected async Task<TResult> PostAsync<TResult>(IRequestParameters parameters, object content, CancellationToken ct = default)
        {
            var uri = CreateRequestUri(parameters);

            using (var httpContent = await CreateContentAsync(content, ct))
            {
                var response = await PostResultAsync<WebApiResponse<TResult>>(uri, httpContent, ct);

                return response.Result;
            }
        }
        private async Task<TResult> PostResultAsync<TResult>(Uri uri, HttpContent content, CancellationToken ct = default)
        {
            using (var httpMessage = CreateHttpRequestMessage(uri, HttpMethod.Post, content))
            {
                using (var responseMessage = await HttpClient.SendAsync(httpMessage, HttpCompletionOption.ResponseHeadersRead, ct).ConfigureAwait(false))
                {
                    return await GetHttpMessageResultAsync<TResult>(responseMessage, ct);
                }
            }
        }
        #endregion

        #region DELETE
        protected async Task<TResult> DeleteAsync<TResult>(IRequestParameters parameters, CancellationToken ct = default)
        {
            var uri = CreateRequestUri(parameters);

            var response = await DeleteResultAsync<WebApiResponse<TResult>>(uri, ct);

            return response.Result;
        }
        private async Task<TResult> DeleteResultAsync<TResult>(Uri uri, CancellationToken ct = default)
        {
            using (var httpMessage = CreateHttpRequestMessage(uri, HttpMethod.Delete))
            {
                using (var responseMessage = await HttpClient.SendAsync(httpMessage, HttpCompletionOption.ResponseHeadersRead, ct).ConfigureAwait(false))
                {
                    return await GetHttpMessageResultAsync<TResult>(responseMessage, ct);
                }
            }
        }
        #endregion

        #endregion

        #region HELPER METHODS

        /// <summary>
        /// Gets the result object from specified response message.
        /// </summary>
        /// <typeparam name="TResult">Result object type.</typeparam>
        /// <param name="httpResponseMessage">HTTP response message.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Result object.</returns>
        protected async Task<TResult> GetHttpMessageResultAsync<TResult>(HttpResponseMessage httpResponseMessage, CancellationToken ct = default)
        {
            if (httpResponseMessage == null)
                throw new ArgumentNullException(nameof(httpResponseMessage));

            //the method will handle a non 200 success code and throw the exception that contains
            //error information provided by web api error result model
            await ThrowApiExceptionIfRequiredAsync(httpResponseMessage, ct);

            try
            {
                //create content stream
                using (var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                {
                    //get our content headers
                    var contentHeaders = httpResponseMessage.Content.Headers;

                    //deserialize the response
                    return await Serializer.DeserializeAsync<TResult>(contentStream, ct);
                }
            }
            catch
            {
                //we will have two kind of possible errors here network related and serialization related
                //we should translate them to custom exceptions so we can handle them appropriately 

                throw;
            }
        }

        /// <summary>
        /// Throws appropriate exception based on HTTP status code and error response.
        /// </summary>
        /// <param name="httpResponseMessage">Http response message.</param>
        protected async Task ThrowApiExceptionIfRequiredAsync(HttpResponseMessage httpResponseMessage, CancellationToken ct)
        {
            //check status code
            //this block will determine if operation is successful and can proceed
            switch (httpResponseMessage.StatusCode)
            {
                //allow normal response message processing in case of OK status code.
                case HttpStatusCode.OK:
                    return;
                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.BadRequest:
                    break;
                default:
                    throw new WebApiClientException(httpResponseMessage.StatusCode, httpResponseMessage.ReasonPhrase);
            }

            //we should only read content stream when there is an serialized response expected
            //as you can see in switch code block there are some http response code that is not expected to
            //have any payload in their response stream

            try
            {
                //once we reached this code block we expect the response to contain an serialized payload
                using (var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                {
                    //deserialize error response
                    var errorResponse = await Serializer.DeserializeAsync<WebApiErrorResponse>(contentStream, ct);

                    //based on the error response we should build appropriate exception
                    //for now we can throw the generic webapiclientexception,
                    //in the future we could have mappings of error response to other exception types
                    ThrowExceptionForResponse(errorResponse);
                }
            }
            catch
            {
                //we will have two kind of possible errors here network related and serialization related
                //we should translate them to custom exceptions so we can handle them appropriately 

                throw;
            }
        }

        /// <summary>
        /// Creates http request message.
        /// </summary>
        /// <param name="uri">Request url.</param>
        /// <param name="method">Request method.</param>
        /// <param name="content">Optional request http content.</param>
        /// <returns>Http request message.</returns>
        protected HttpRequestMessage CreateHttpRequestMessage(Uri uri, HttpMethod method, HttpContent? content = default)
        {
            //create request message with desired content
            var requestMessage = new HttpRequestMessage(method, uri) { Content = content };

            //get default accept header value
            var defaultAcceptHeader = Serializer.DefaultAcceptHeader;

            //set accept header for our request message
            requestMessage.Headers.Add(HeaderNames.Accept, defaultAcceptHeader);

            //return request message
            return requestMessage;
        }

        /// <summary>
        /// Throws appropriate exception based on web api response object.
        /// </summary>
        /// <param name="errorResponse">Web api response object.</param>
        protected virtual void ThrowExceptionForResponse(WebApiErrorResponse errorResponse)
        {
            if (errorResponse == null)
                throw new ArgumentNullException(nameof(errorResponse));

            //throw generic non-error code web api client exception
            throw new WebApiClientException((HttpStatusCode)errorResponse.HttpStatusCode,
                errorResponse.Message,
                errorResponse.ErrorCodeType,
                errorResponse.ErrorCodeTypeReadable,
                errorResponse.ErrorCode,
                errorResponse.ErrorCodeReadable,
                errorResponse.Errors);
        } 

        #endregion

        #region SERIALIZATION

        /// <summary>
        /// Creates appropriate Http Content based on current client options.
        /// </summary>
        /// <param name="obj">Content object.</param>
        /// <returns>HttpContent.</returns>
        protected ValueTask<HttpContent> CreateContentAsync<T>(T obj, CancellationToken ct)
        {
            //allow null object , this will be represented with empty content
            if (obj == null)
                return new ValueTask<HttpContent>();

            try
            {
                //create the http content with current serializer
                return Serializer.CreateContentAsync(obj, default, ct);
            }
            catch
            {
                //here we would get an serialization related error
                //should create custom exception for handling it, the excption should have inner exception set so we can 
                //obtain more information on what was the root cause

                throw;
            }
        }

        #endregion
    }
}
