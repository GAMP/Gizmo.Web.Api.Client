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
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<InvoiceModel>>(parameters, ct);
        }

        public Task<InvoiceModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<InvoiceModel>(parameters, ct);
        }

        public Task<UpdateResult> VoidAsync(int id, IRefundOptions model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "void" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        #endregion
    }
}