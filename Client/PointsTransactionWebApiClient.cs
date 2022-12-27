using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Models.API.Request.Transaction.Point;
using Gizmo.Web.Api.Models.Models.API.Request;

namespace Gizmo.Web.Api.Client
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
        public Task<PagedList<PointTransactionModel>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }
        #endregion

        #region GET
        public Task<PagedList<PointTransactionModel>> GetAsync(PointTransactionFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<PointTransactionModel>>(filter, ct);
        }
        #endregion

        #region CREATE
        public Task<CreateResult> CreateAsync(PointTransactionModelCreate pointTransactionModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), pointTransactionModelCreate, ct);
        }
        #endregion

        #region GET BY ID
        public Task<PointTransactionModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<PointTransactionModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        } 
        #endregion
    }
}
