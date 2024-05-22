using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/deposittransactions")]
    public sealed class DepositTransactionsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public DepositTransactionsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<DepositTransactionModel>> GetAsync(DepositTransactionsFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<DepositTransactionModel>>(parameters, ct);
        }

        public Task<DepositTransactionModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<DepositTransactionModel>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(DepositTransactionModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        #endregion
    }
}
