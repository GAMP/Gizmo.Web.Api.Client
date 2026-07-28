using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Device activation web api client.
    /// </summary>
    /// <remarks>
    /// Anonymous endpoints: unauthenticated devices create an activation session, show its
    /// nonce as QR / human code for the phone approval portal and long poll for the outcome.
    /// </remarks>
    [UnsecureWebApiClient()]
    [WebApiRoute("api/v3/deviceauth")]
    public sealed class DeviceAuthWebApiClient : WebApiClientBase
    {
        /// <inheritdoc cref="WebApiClientBase(HttpClient, IOptions{WebApiClientOptions}, IPayloadSerializerProvider)"/>
        public DeviceAuthWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
          base(httpClient, options, payloadSerializerProvider)
        {
        }

        /// <summary>
        /// Creates a device activation session.
        /// </summary>
        public Task<DeviceAuthSessionResultModel> SessionCreateAsync(DeviceAuthSessionCreateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["sessions"]);
            return PostAsync<DeviceAuthSessionResultModel>(parameters, model, cancellationToken);
        }

        /// <summary>
        /// Long polls the activation session outcome. Blocks up to the server poll window;
        /// a pending result means poll again.
        /// </summary>
        public Task<DeviceAuthWaitResultModel> SessionWaitAsync(DeviceAuthWaitParametersModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "sessions", "wait" }, model);
            return GetAsync<DeviceAuthWaitResultModel>(parameters, cancellationToken);
        }

        /// <summary>
        /// Refreshes a device access token, consuming the single use refresh token.
        /// </summary>
        public Task<AuthTokenResultModel> RefreshAsync(AccessTokenRefreshRequestModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["refresh"]);
            return PostAsync<AuthTokenResultModel>(parameters, model, cancellationToken);
        }
    }
}
