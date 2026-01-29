using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/operators")]
    public sealed class OperatorsWebApiClient : WebApiClientBase
    {
        public OperatorsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<OperatorModel>> GetAsync(OperatorsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<OperatorModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(OperatorModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(OperatorModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<OperatorModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<OperatorModel>(parameters, cancellationToken);
        }

        public Task<OperatorModel> CurrentAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["current"]);
            return GetAsync<OperatorModel>(parameters, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<PagedList<BranchModel>> BranchesAsync(OpeatorBranchFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["current", "branches"], filter);
            return GetAsync<PagedList<BranchModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> AddToBranch(int id, int branchId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "branches", branchId]);
            return PostAsync<CreateResult>(parameters, cancellationToken);
        }

        public Task<DeleteResult> RemoveFromBranchAsync(int id, int branchId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "branches", branchId]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<UpdateResult> SetDefaultBranchAsync(int id, int branchId, bool isDefault, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "branches", branchId, "default", isDefault ]);
            return PutAsync<UpdateResult>(parameters, cancellationToken);
        }

        public Task<int?> GetDefaultBranchAsync(int id,  CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "branches", "default"]);
            return GetAsync<int?>(parameters, cancellationToken);
        }

        public Task<PagedList<BranchModel>> BranchesAsync(int operatorId, OpeatorBranchFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([operatorId, "branches"], filter);
            return GetAsync<PagedList<BranchModel>>(parameters, cancellationToken);
        }

        public Task<BranchModel?> BranchCurrentAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["current", "branches", "current"]);
            return GetAsync<BranchModel?>(parameters, cancellationToken);
        }

        public Task<PagedList<RegisterModel>> RegistersAsync(int branchId, OperatorRegisterFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["current", "branches", branchId, "registers"], filter);
            return GetAsync<PagedList<RegisterModel>>(parameters, cancellationToken);
        }

        public Task<PagedList<RegisterModel>> RegistersAsync(OperatorRegisterFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["current", "registers"], filter);
            return GetAsync<PagedList<RegisterModel>>(parameters, cancellationToken);
        }

        public Task<RegisterModel?> RegisterCurrentAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["current", "registers", "current"]);
            return GetAsync<RegisterModel?>(parameters, cancellationToken);
        }

        public Task<CreateResult> ShiftStartAsync(ShiftStartModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["current", "shifts", "start"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<CreateResult> ShiftStartAsync(int id, ShiftStartModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "shifts", "start"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<ActiveShiftModel> ShiftActiveAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["current", "shifts", "active"]);
            return GetAsync<ActiveShiftModel>(parameters, cancellationToken);
        }

        public Task<UpdateResult> ShiftActiveEndAsync(ShiftEndModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["current", "shifts", "active", "end"]);
            return PostAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> ShiftActiveLockAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["current", "shifts", "active", "lock"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<UpdateResult> ShiftActiveUnlockAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["current", "shifts", "active", "unlock"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<ShiftOptionsModel> ShiftOptionsAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["current", "shifts", "options"]);
            return GetAsync<ShiftOptionsModel>(parameters, cancellationToken);
        }

        public Task<ShiftExpectedModel> ShiftActiveExpectedAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["current", "shifts", "active" , "expected"]);
            return GetAsync<ShiftExpectedModel>(parameters, cancellationToken);
        }

        public Task<UpdateResult> PasswordUpdateAsync(OperatorPasswordUpdateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["current", "password"]);
            return PostAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> EnableAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "enable"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<UpdateResult> DisableAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "disable"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<UpdateResult> PermissionsSetAsync(int id, int permissionSetId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "permissionsets", permissionSetId]);
            return GetAsync<UpdateResult>(parameters, cancellationToken);
        }

    }
}
