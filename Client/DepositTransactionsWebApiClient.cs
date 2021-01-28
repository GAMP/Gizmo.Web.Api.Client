using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/deposittransactions")]
    public class DepositTransactionsWebApiClient : WebApiClientBase
    {
        public DepositTransactionsWebApiClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<PagedList<DepositTransaction>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<DepositTransaction>> GetAsync(DepositTransactionsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<DepositTransaction>>(filter, ct);
        }

        public Task<DepositTransaction> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<DepositTransaction>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<CreateResult> CreateAsync(DepositTransactionModelCreate depositTransactionModelCreate, CancellationToken ct = default)
        {
            return PutAsync<CreateResult>(CreateRequestUrl(), depositTransactionModelCreate, ct);
        }
    }
}
