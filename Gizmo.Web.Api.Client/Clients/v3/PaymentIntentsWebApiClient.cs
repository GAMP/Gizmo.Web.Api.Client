using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/paymentintents")]
    public sealed class PaymentIntentsWebApiClient : WebApiClientBase
    {
        public PaymentIntentsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<PaymentIntentModel>> GetAsync(PaymentIntentFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<PaymentIntentModel>>(parameters, cancellationToken);
        }

        public Task<PaymentIntentModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<PaymentIntentModel>(parameters, cancellationToken);
        }

        public Task<PaymentIntentModel> GetAsync(Guid identifier, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([identifier]);
            return GetAsync<PaymentIntentModel>(parameters, cancellationToken);
        }

        public Task<PaymentIntentCreateResultModel> CreateAsync(PaymentIntentCreateParametersDepositModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<PaymentIntentCreateResultModel>(parameters, model, cancellationToken);
        }

        public Task<PaymentIntentCancelResultModel> CancelAsync(Guid identifier, CancellationToken cancellationToken = default)
        {
            return PostAsync<PaymentIntentCancelResultModel>(new UriParameters([identifier, "cancel"]), cancellationToken);
        }

        public Task<PaymentIntentOrderModel> OrderAsync(Guid identifier, CancellationToken cancellationToken = default)
        {
            return GetAsync<PaymentIntentOrderModel>(new UriParameters([identifier, "order"]), cancellationToken);
        }

        /// <summary>
        /// Waits for payment intent to complete and returns its final state.
        /// </summary>
        /// <param name="identifier">Payment intent identifier.</param>
        /// <param name="waitForCompleted">
        /// When false (default) the wait returns on the first transition out of pending (Captured on success),
        /// before the order/deposit and its invoices are materialized. When true the wait blocks until the intent
        /// is fully processed (Completed/Failed), so created invoices and deposit payments can be read immediately after.
        /// </param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Final state.</returns>
        /// <remarks>
        /// This function will block until the payment intent reaches a final state (Completed, Failed, Expired, Cancelled, Captured, Declined).<br></br>
        /// It will return immediately if the payment intent is already in a final state.<br></br>
        /// </remarks>
        public Task<PaymentIntentState> WaitAsync(Guid identifier, bool waitForCompleted = false, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, string>() { [nameof(waitForCompleted)] = waitForCompleted.ToString() };
            return GetAsync<PaymentIntentState>(new UriParameters([identifier, "wait"], query), cancellationToken);
        }

        public Task<UpdateResult> DiscardAsync(Guid identifier, CancellationToken cancellationToken = default)
        {
            return PostAsync<UpdateResult>(new UriParameters([identifier, "discard"]), cancellationToken);
        }
    }
}
