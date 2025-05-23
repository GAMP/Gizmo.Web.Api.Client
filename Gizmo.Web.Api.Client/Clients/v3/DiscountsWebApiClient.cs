using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Client.Clients.v3
{
    [WebApiRoute("api/v3/discounts")]
    public sealed class DiscountsWebApiClient : WebApiClientBase
    {
        public DiscountsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<DiscountModel>> GetAsync(DiscountFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<DiscountModel>>(parameters, cancellationToken);
        }

        public Task<DiscountModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<DiscountModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(DiscountModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(DiscountModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public async Task<UpdateResult> RenameAsync(int id, string name, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "name"]);
            return await PutAsync<UpdateResult>(parameters, name, cancellationToken).ConfigureAwait(false);
        }

        public async Task<ExistResult> NameExistAsync(string name, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["name", name, "exist"]);
            return await GetAsync<ExistResult>(parameters, cancellationToken).ConfigureAwait(false);
        }
         
        public async Task<UpdateResult> DescriptionAsync(int id, string name, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "description"]);
            return await PutAsync<UpdateResult>(parameters, name, cancellationToken).ConfigureAwait(false);
        }

        public Task<IEnumerable<BranchReferenceModel>> BranchesGetAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "branches"]);
            return GetAsync<IEnumerable<BranchReferenceModel>>(parameters, cancellationToken);
        }

        public Task<UpdateResult> BranchSetAsync(int id, IEnumerable<BranchReferenceModelUpdate> entries, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "branches"]);
            return PostAsync<UpdateResult>(parameters, entries, cancellationToken);
        }

        public Task<DeleteResult> EnableAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "enable"]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<UpdateResult> DisableAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "disable"]);
            return PutAsync<UpdateResult>(parameters, cancellationToken, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UnDeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "undelete"]);
            return PutAsync<UpdateResult>(parameters, cancellationToken, cancellationToken);
        }
    }
}
