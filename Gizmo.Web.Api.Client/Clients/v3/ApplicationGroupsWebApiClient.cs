using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/applicationgroups")]
    public sealed class ApplicationGroupsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationGroupsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ApplicationGroupModel>> GetAsync(ApplicationGroupsFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ApplicationGroupModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationGroupModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationGroupModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<ApplicationGroupModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ApplicationGroupModel>(parameters, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {   
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<IEnumerable<ApplicationGroupApplicationModel>> ApplicationGroupApplicationsGet(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "applications"]);
            return GetAsync<IEnumerable<ApplicationGroupApplicationModel>>(parameters, ct);
        }

        public Task<CreateResult> ApplicationGroupApplicationsCreate(ApplicationGroupApplicationsModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(["applications", "create"]);
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> ApplicationGroupApplicationsUpdate(ApplicationGroupApplicationsModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(["applications", "update"]);
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        #endregion
    }
}
