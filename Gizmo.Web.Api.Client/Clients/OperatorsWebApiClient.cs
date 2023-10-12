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
        public OperatorsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

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

        public Task<OperatorModel> CurrentAsync(CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] {"current"});
            return GetAsync<OperatorModel>(parameters, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<PagedList<BranchModel>> BranchesAsync(OpeatorBranchFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "current", "branches" }, filter);
            return GetAsync<PagedList<BranchModel>>(parameters, cancellationToken);
        }

        public Task<PagedList<BranchModel>> BranchesAsync(int operatorId, OpeatorBranchFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { operatorId, "branches" }, filter);
            return GetAsync<PagedList<BranchModel>>(parameters, cancellationToken);
        }

        public Task<BranchModel?> BranchCurrentAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "current", "branches", "current" });
            return GetAsync<BranchModel?>(parameters, cancellationToken);
        }

        public Task<PagedList<RegisterModel>> RegistersAsync(int branchId, OperatorRegisterFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "current", "branches", branchId, "registers" }, filter);
            return GetAsync<PagedList<RegisterModel>>(parameters, cancellationToken);
        }

        public Task<PagedList<RegisterModel>> RegistersAsync(OperatorRegisterFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "current", "registers" }, filter);
            return GetAsync<PagedList<RegisterModel>>(parameters, cancellationToken);
        }

        public Task<RegisterModel?> RegisterCurrentAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "current", "registers", "current" });
            return GetAsync<RegisterModel?>(parameters, cancellationToken);
        }

        public Task<CreateResult> ShiftStartAsync(ShiftStartModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new[] { "current", "shift", "start" });
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<CreateResult> ShiftStartAsync(int operatorId, ShiftStartModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { operatorId, "shift", "start" });
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<ActiveShiftModel> ShiftActiveAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "current", "shift", "active" });
            return GetAsync<ActiveShiftModel>(parameters, cancellationToken);
        }

        public Task<UpdateResult> ShiftActiveEndAsync(ShiftEndModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "current", "shift", "active", "end" });
            return PostAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> ShiftActiveLockAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "current", "shift", "active", "lock" });
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<UpdateResult> ShiftActiveUnlockAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "current", "shift", "active", "unlock" });
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<ShiftOptionsModel> ShiftOptionsAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "current", "shift", "options"});
            return GetAsync<ShiftOptionsModel>(parameters, cancellationToken);
        }
    }
}
