using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/registertransactions")]
    public sealed class RegisterTransactionsWebApiClient : WebApiClientBase
    {
        public RegisterTransactionsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        public Task<PagedList<RegisterTransactionModel>> GetAsync(RegisterTransactionsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<RegisterTransactionModel>>(parameters, cancellationToken);
        }

        public Task<RegisterTransactionModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<RegisterTransactionModel>(parameters, cancellationToken);
        }

        public async Task<CreateResult> CreateAsync(RegisterTransactionModelCreate model, CancellationToken cancellationToken = default)
        {
            return await PostAsync<CreateResult>(UriParameters.Empty, model, cancellationToken).ConfigureAwait(false);
        }
    }
}
