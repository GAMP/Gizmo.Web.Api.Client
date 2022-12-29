using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/registertransactions")]
    public class RegisterTransactionsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public RegisterTransactionsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

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
        
        #endregion
    }
}
