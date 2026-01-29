using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/hostgroups")]
    public sealed class HostGroupsWebApiClient : WebApiClientBase
    {
        public HostGroupsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<HostGroupModel>> GetAsync(HostGroupsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<HostGroupModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(HostGroupModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(HostGroupModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<HostGroupModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<HostGroupModel>(parameters, cancellationToken);
        }

        public Task<HostGroupDeleteResultModel> DeleteAsync(int id, HostGroupDeleteOptionsModel options, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id], options);
            return DeleteAsync<HostGroupDeleteResultModel>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UpdateBillingProfile(int id, int billingProfileId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "billingprofiles", billingProfileId]);
            return PutAsync<UpdateResult>(parameters, cancellationToken);
        }

        public Task<DeleteResult> DeleteBillingProfile(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "billingprofiles"]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }
    }
}
