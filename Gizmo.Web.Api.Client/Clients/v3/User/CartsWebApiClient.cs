using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    [WebApiRoute("api/user/v3/carts")]
    public sealed class CartsWebApiClient : WebApiClientBase
    {
        public CartsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
           base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<CartCreateResultModel> CreateAsync(CancellationToken cancellationToken = default)
        {
            return PostAsync<CartCreateResultModel>(UriParameters.Empty, cancellationToken);
        }

        public Task<CartDeleteResultModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id]);
            return DeleteAsync<CartDeleteResultModel>(parameters, cancellationToken);
        }

        public Task<CartClearResultModel> ClearAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "clear"]);
            return PostAsync<CartClearResultModel>(parameters, cancellationToken);
        }

        public Task<CartEntryAddResultModel> AddAsync(Guid id, CartEntryProductAddModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "entries"]);
            return PostAsync<CartEntryAddResultModel>(parameters, model, cancellationToken);
        }

        public Task<CartEntryRemoveResultModel> RemoveAsync(Guid id, Guid entryId, CancellationToken cancellationToken)
        {
            var parameters = new UriParameters([id, "entries", entryId]);
            return DeleteAsync<CartEntryRemoveResultModel>(parameters, cancellationToken);
        }

        public Task<CartEntryQuantityResultModel> QuantityAsync(Guid id, Guid entryId, decimal quantity, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "entries", entryId, "quantity", quantity]);
            return PutAsync<CartEntryQuantityResultModel>(parameters, cancellationToken);
        }

        public Task<CartPromotionCodeAddModel> PromotionCodeAddAsync(Guid id, CartPromotionCodeAddModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "promotion"]);
            return PutAsync<CartPromotionCodeAddModel>(parameters, model, cancellationToken);
        }

        public Task<CartPromotionCodeRemoveModel> PromotionCodeRemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "promotion"]);
            return DeleteAsync<CartPromotionCodeRemoveModel>(parameters, cancellationToken);
        }

        public Task<CartEntryPayTypeResultModel> PayTypeAsync(Guid id, Guid entryId, Gizmo.OrderLinePayType payType, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "entries", entryId, "paymentType", payType]);
            return PutAsync<CartEntryPayTypeResultModel>(parameters, cancellationToken);
        }

        public Task<CartPaymentMethodSetResultModel> PaymentMethodSetAsync(Guid id, CartPaymentMethodSetModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "paymentMethod"]);
            return PostAsync<CartPaymentMethodSetResultModel>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> NoteAsync(Guid id, string? note, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "note"], new Dictionary<string, string>() { { "Note", note ?? string.Empty } });
            return PutAsync<UpdateResult>(parameters, cancellationToken);
        }

        public Task<CartStateModel> StateAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "state"]);
            return GetAsync<CartStateModel>(parameters, cancellationToken);
        }

        public Task<CartPaymentsStateModel> PaymentsStateAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "payments", "state"]);
            return GetAsync<CartPaymentsStateModel>(parameters, cancellationToken);
        }

        public Task<CartAcceptResultModel> AcceptAsync(Guid id, UserCartAcceptModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "accept"]);
            return PostAsync<CartAcceptResultModel>(parameters, model, cancellationToken);
        }
    }
}
