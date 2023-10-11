using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/operators")]
    public sealed class OperatorsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public OperatorsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<OperatorModel>> GetAsync(OperatorsFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<OperatorModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(OperatorModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(OperatorModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<OperatorModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<OperatorModel>(parameters, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        #endregion

        public Task<PagedList<BranchModel>> BranchesAsync(OpeatorBranchFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "branches" }, filter);
            return GetAsync<PagedList<BranchModel>>(parameters, cancellationToken);
        }

        public Task<BranchModel?> BranchCurrentAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "branches", "current" });
            return GetAsync<BranchModel?>(parameters, cancellationToken);
        }

        public Task<PagedList<RegisterModel>> RegistersAsync(int branchId, OperatorRegisterFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "branches", branchId, "registers" }, filter);
            return GetAsync<PagedList<RegisterModel>>(parameters, cancellationToken);
        }

        public Task<PagedList<RegisterModel>> RegistersAsync(OperatorRegisterFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "registers" }, filter);
            return GetAsync<PagedList<RegisterModel>>(parameters, cancellationToken);
        }

        public Task<RegisterModel?> RegisterCurrentAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "registers", "current" });
            return GetAsync<RegisterModel?>(parameters, cancellationToken);
        }
    }
}
