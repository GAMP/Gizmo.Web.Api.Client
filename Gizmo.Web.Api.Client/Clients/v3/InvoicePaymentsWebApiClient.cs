using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/invoicepayments")]
    public sealed class InvoicePaymentsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public InvoicePaymentsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<InvoicePaymentModel>> GetAsync(InvoicePaymentsFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<InvoicePaymentModel>>(parameters, ct);
        }

        public Task<InvoicePaymentModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<InvoicePaymentModel>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(InvoicePaymentModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);        
        } 

        #endregion
    }
}
