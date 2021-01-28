using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/registertransactions")]
    public class RegisterTransactionsWebApiClient : WebApiClientBase
    {
        public RegisterTransactionsWebApiClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<PagedList<RegisterTransaction>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<RegisterTransaction>> GetAsync(RegisterTransactionsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<RegisterTransaction>>(filter, ct);
        }

        public Task<RegisterTransaction> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<RegisterTransaction>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<CreateResult> CreateAsync(RegisterTransactionModelCreate registerTransactionModelCreate, CancellationToken ct = default)
        {
            return PutAsync<CreateResult>(CreateRequestUrl(), registerTransactionModelCreate, ct);
        }
    }
}
