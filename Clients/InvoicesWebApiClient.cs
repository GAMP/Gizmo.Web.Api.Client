using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Abstractions;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
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

        public Task<PagedList<InvoiceModel>> GetAsync(InvoicesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<InvoiceModel>>(filter, ct);
        }

        public Task<InvoiceModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<InvoiceModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<UpdateResult> VoidAsync(int id, IRefundOptions refundOptions, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"{id}/void"), refundOptions, ct);
        }

        #endregion
    }
}