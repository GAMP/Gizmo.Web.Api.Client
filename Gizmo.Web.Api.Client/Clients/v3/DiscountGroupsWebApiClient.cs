using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/discountgroups")]
    public sealed class DiscountGroupsWebApiClient : WebApiClientBase
    {
        public DiscountGroupsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<DiscountGroupModel>> GetAsync(DiscountGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<DiscountGroupModel>>(parameters, cancellationToken);
        }

        public Task<DiscountGroupModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<DiscountGroupModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(DiscountGroupModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(DiscountGroupModelUpdate model, CancellationToken cancellationToken = default)
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
            return PutAsync<UpdateResult>(parameters, cancellationToken, cancellationToken);
        }

        public async Task<ExistResult> NameExistAsync(string name, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["name", name, "exist"]);
            return await GetAsync<ExistResult>(parameters, cancellationToken).ConfigureAwait(false);
        }
    }
}
