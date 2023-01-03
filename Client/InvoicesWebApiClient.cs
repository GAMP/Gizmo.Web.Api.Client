using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Abstractions;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/invoices")]
    public class InvoicesWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public InvoicesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<Invoice>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<Invoice>> GetAsync(InvoicesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<Invoice>>(filter, ct);
        }

        public Task<Invoice> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<Invoice>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<UpdateResult> VoidAsync(int id, IRefundOptions refundOptions, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"{id}/void"), refundOptions, ct);
        }

        #endregion
    }
}