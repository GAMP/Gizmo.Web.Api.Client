using System.Collections.Generic;
using System.Net.Http;
using Gizmo.Web.Api.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/branches")]
    public sealed class BranchesWebApiClient : WebApiClientBase
    {
        public BranchesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<BranchModel>> GetAsync(BranchFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<BranchModel>>(parameters, cancellationToken);
        }

        public Task<BranchModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<BranchModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(BranchModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(BranchModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UndeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "undelete"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<ExistResult> NameExistAsync(string name, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["name", "exists"], new Dictionary<string, string> { ["name"] = name });
            return GetAsync<ExistResult>(parameters, cancellationToken);
        }

        public Task<TimeZoneInfoModel> TimeZoneAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "timezone"]);
            return GetAsync<TimeZoneInfoModel>(parameters, cancellationToken);
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

        public Task<BranchCountersModel> CountersAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "counters"]);
            return GetAsync<BranchCountersModel>(parameters, cancellationToken);
        }
    }
}
