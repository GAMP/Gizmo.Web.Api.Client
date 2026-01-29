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

        public Task<PagedList<ApplicationGroupModel>> GetAsync(ApplicationGroupsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ApplicationGroupModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(ApplicationGroupModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationGroupModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<ApplicationGroupModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ApplicationGroupModel>(parameters, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {   
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<IEnumerable<ApplicationGroupApplicationModel>> ApplicationGroupApplicationsGet(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "applications"]);
            return GetAsync<IEnumerable<ApplicationGroupApplicationModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> ApplicationGroupApplicationsCreate(ApplicationGroupApplicationsModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["applications", "create"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> ApplicationGroupApplicationsUpdate(ApplicationGroupApplicationsModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["applications", "update"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> ApplicationApplicationGroupsUpdate(int applicationId, ApplicationApplicationGroupsModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["applications", applicationId, "update"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<IEnumerable<ApplicationGroupApplicationModel>> ApplicationApplicationGroupsGet(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["application", id]);
            return GetAsync<IEnumerable<ApplicationGroupApplicationModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> ApplicationApplicationGroupCreate(int applicationId, int applicationGroupId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["application", applicationId, applicationGroupId]);
            return PostAsync<CreateResult>(parameters, cancellationToken);
        }

        public Task<DeleteResult> ApplicationApplicationGroupDelete(int applicationId, int applicationGroupId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["applications", applicationId, applicationGroupId]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        #endregion
    }
}
