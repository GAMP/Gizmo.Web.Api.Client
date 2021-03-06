﻿using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/paymentmethods")]
    public class PaymentMethodWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public PaymentMethodWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<PaymentMethod>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<PaymentMethod>> GetAsync(PaymentMethodsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<PaymentMethod>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(PaymentMethodModelCreate paymentMethodModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), paymentMethodModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(PaymentMethodModelUpdate paymentMethodModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), paymentMethodModelUpdate, ct);
        }

        public Task<PaymentMethod> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<PaymentMethod>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
