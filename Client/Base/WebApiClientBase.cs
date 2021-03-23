using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Reflection;
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
        public IOptions<WebApiClientOptions> Options
        {
            get; set;
        }

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
            if (routeAttribute == null)
                throw new ArgumentNullException("Route attribute is not specified for the client.", nameof(routeAttribute));

            return routeAttribute.Route;
        }

        protected virtual string CreateRequestUrlWithRouteParameters(string routeParameters)
        {
            return CreateRequestUrl(routeParameters, default(IUrlQueryParameters));
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
            return CreateRequestUrl(default(IUrlRouteParameters), queryParameters);
        }

        protected virtual string CreateRequestUrl(string routeParameters, IUrlQueryParameters queryParameters)
        {
            return CreateRequestUrl(routeParameters, ParameterGenerator.Generate(queryParameters));
        }

        protected virtual string CreateRequestUrl(IUrlRouteParameters routeParameters, IUrlQueryParameters queryParameters)
        {
            return CreateRequestUrl(ParameterGenerator.Generate(routeParameters), ParameterGenerator.Generate(queryParameters));
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

        protected async Task<TResult> GetResultAsync<TResult>(string requestUri, HttpContent content, CancellationToken ct = default)
        {
            using (var httpMessage = CreateHttpRequestMessage(requestUri, HttpMethod.Get, content))
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
                case System.Net.HttpStatusCode.OK:
                    return;
                case System.Net.HttpStatusCode.NotFound:
                    //custom not found exception could be thrown here in order to easily diagnose problems related to invalid routes
                    break;
                case System.Net.HttpStatusCode.Unauthorized:
                    //when the request is unauthorized we wont be hitting any endpoints so response will be plain text
                    //we should throw custom unauthorized excption here
                    break;       
                default:
                    //we will need examine other http status codes, some might mean success some not so we would need to handle them here
                    break;
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

                    //WARNING
                    //WebApiClientException class still need work in order to be able to provide all errors contained in the errorResponse

                    //throw appropriate exception
                    throw new WebApiClientException(httpResponseMessage.StatusCode, httpResponseMessage.ReasonPhrase, errorResponse.ErrorCode);
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
        /// <param name="requestUrl">Request url.</param>
        /// <param name="method">Request method.</param>
        /// <param name="content">Optional request http content.</param>
        /// <returns>Http request message.</returns>
        protected HttpRequestMessage CreateHttpRequestMessage(string requestUrl, HttpMethod method, HttpContent content = default)
        {
            return new HttpRequestMessage(method, requestUrl) { Content = content };
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
