using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    /// <summary>
    /// Payments api client, user surface — online top up of the authenticated user's own balance.
    /// </summary>
    [WebApiRoute("api/user/v3/payments")]
    public sealed class PaymentsWebApiClient : WebApiClientBase
    {
        public PaymentsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        /// <summary>
        /// Gets the top up options (presets, limits) and the enabled online payment methods.
        /// </summary>
        public Task<UserPaymentOptionsModel> OptionsAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["options"]);
            return GetAsync<UserPaymentOptionsModel>(parameters, cancellationToken);
        }

        /// <summary>
        /// Starts an online top up of the user balance; returns the payment page url.
        /// </summary>
        public Task<UserPaymentIntentModel> DepositAsync(UserDepositCreateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["deposit"]);
            return PostAsync<UserPaymentIntentModel>(parameters, model, cancellationToken);
        }

        /// <summary>
        /// Gets the state of an own payment intent.
        /// </summary>
        public Task<UserPaymentIntentStateModel> StateAsync(UserPaymentIntentFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["state"], filter);
            return GetAsync<UserPaymentIntentStateModel>(parameters, cancellationToken);
        }

        /// <summary>
        /// Cancels an own pending top up; returns the state of the intent.
        /// </summary>
        public Task<UserPaymentIntentStateModel> CancelAsync(UserPaymentIntentCancelModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["cancel"]);
            return PutAsync<UserPaymentIntentStateModel>(parameters, model, cancellationToken);
        }
    }
}
