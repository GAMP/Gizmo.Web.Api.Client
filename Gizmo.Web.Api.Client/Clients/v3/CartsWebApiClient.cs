using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/carts")]
    public sealed class CartsWebApiClient : WebApiClientBase
    {
        public CartsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
           base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<CartCreateResultModel> CreateAsync(CartCreateModel model, CancellationToken cancellationToken = default)
        {
            return PostAsync<CartCreateResultModel>(UriParameters.Empty, model, cancellationToken);
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

        public Task<CartUserAddResultModel> UserAddAsync(Guid id, int userId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "users", userId]);
            return PutAsync<CartUserAddResultModel>(parameters, cancellationToken);
        }

        public Task<CartUserSwapResultModel> UserSwapAsync(Guid id, int userId, int newUserId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "users", userId, "swap", newUserId]);
            return PutAsync<CartUserSwapResultModel>(parameters, cancellationToken);
        }

        public Task<CartUserRemoveResultModel> UserRemoveAsync(Guid id, int userId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "users", userId]);
            return DeleteAsync<CartUserRemoveResultModel>(parameters, cancellationToken);
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

        public Task<CartEntryAddResultModel> AddAsync(Guid id, int userId, CartEntryProductAddModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "entries", "users", userId]);
            return PostAsync<CartEntryAddResultModel>(parameters, model, cancellationToken);
        }

        public Task<CartEntryAddResultModel> AddAsync(Guid id, int userId, CartEntryDepositAddModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "entries", "users", userId, "deposit"]);
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

        public Task<CartEntryPriceResultModel> PriceAsync(Guid id, Guid entryId, decimal? price, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "entries", entryId, "price", price!]);
            return PutAsync<CartEntryPriceResultModel>(parameters, cancellationToken);
        }

        public Task<CartEntryPriceResultModel> PointsPriceAsync(Guid id, Guid entryId, int? price, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "entries", entryId, "price", "point", price!]);
            return PutAsync<CartEntryPriceResultModel>(parameters, cancellationToken);
        }

        public Task<CartEntryPayTypeResultModel> PayTypeAsync(Guid id, Guid entryId, Gizmo.OrderLinePayType payType, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "entries", entryId, "paymentType", payType]);
            return PutAsync<CartEntryPayTypeResultModel>(parameters, cancellationToken);
        }

        public Task<CartPaymentAddResultModel> PaymentAddAsync(Guid id, PaymentCreateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "payments"]);
            return PostAsync<CartPaymentAddResultModel>(parameters, model, cancellationToken);
        }

        public Task<CartPaymentAddResultModel> PaymentRemoveAsync(Guid id, int paymentMethodId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "payments", paymentMethodId]);
            return DeleteAsync<CartPaymentAddResultModel>(parameters, cancellationToken);
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

        public Task<UpdateResult> NoteAsync(Guid id, int userId, string? note, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "users", userId, "note"], new Dictionary<string, string>() { { "Note", note ?? string.Empty } });
            return PutAsync<UpdateResult>(parameters, cancellationToken);
        }

        public Task<CartAcceptResultModel> AcceptAsync(Guid id, CartAcceptModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "accept"]);
            return PostAsync<CartAcceptResultModel>(parameters, model, cancellationToken);
        }
    }
}
