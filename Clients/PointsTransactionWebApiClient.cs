using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/pointstransactions")]
    public class PointsTransactionWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public PointsTransactionWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region GET
        public Task<PagedList<PointTransactionModel>> GetAsync(PointTransactionFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<PointTransactionModel>>(parameters, ct);
        }
        #endregion

        #region CREATE
        public Task<CreateResult> CreateAsync(PointTransactionModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }
        #endregion

        #region GET BY ID
        public Task<PointTransactionModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<PointTransactionModel>(parameters, ct);
        } 
        #endregion
    }
}
