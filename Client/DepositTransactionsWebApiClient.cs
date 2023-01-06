using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/deposittransactions")]
    public class DepositTransactionsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public DepositTransactionsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<DepositTransactionModel>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<DepositTransactionModel>> GetAsync(DepositTransactionsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<DepositTransactionModel>>(filter, ct);
        }

        public Task<DepositTransactionModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<DepositTransactionModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<CreateResult> CreateAsync(DepositTransactionModelCreate depositTransactionModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), depositTransactionModelCreate, ct);
        }

        #endregion
    }
}
