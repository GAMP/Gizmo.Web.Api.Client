using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Abstractions;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/invoices")]
    public sealed class InvoicesWebApiClient : WebApiClientBase
    {
        public InvoicesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<InvoiceModel>> GetAsync(InvoicesFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<InvoiceModel>>(parameters, cancellationToken);
        }

        public Task<InvoiceModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<InvoiceModel>(parameters, cancellationToken);
        }

        public Task<UpdateResult> VoidAsync(int id, IRefundOptions model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "void"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<decimal> LineQuantityAsync(int invoiceLineId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["lines", invoiceLineId, "quantity"]);
            return GetAsync<decimal>(parameters, cancellationToken);
        }
    }
}
