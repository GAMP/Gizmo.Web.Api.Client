using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/applicationexecutables")]
    public sealed class ApplicationExecutablesWebApiClient : WebApiClientBase
    {
        public ApplicationExecutablesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<ApplicationExecutableModel>> GetAsync(ApplicationExecutablesFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ApplicationExecutableModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(ApplicationExecutableModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationExecutableModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<ApplicationExecutableModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ApplicationExecutableModel>(parameters, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<IEnumerable<ApplicationExecutablePersonalFileModel>> GetApplicationExecutablePersonalFiles(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "personalfiles"]);
            return GetAsync<IEnumerable<ApplicationExecutablePersonalFileModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateApplicationExecutablePersonalFile(int id, ApplicationExecutablePersonalFileModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "personalfiles"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateApplicationExecutablePersonalFile(ApplicationExecutablePersonalFileModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["personalfiles"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteApplicationExecutablePersonalFile(int id, int personalFileId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "personalfiles", personalFileId]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<IEnumerable<ApplicationExecutableDeploymentModel>> GetApplicationExecutableDeployments(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "deployments"]);
            return GetAsync<IEnumerable<ApplicationExecutableDeploymentModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateApplicationExecutableDeployment(int id, ApplicationExecutableDeploymentModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "deployments"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateApplicationExecutableDeployment(ApplicationExecutableDeploymentModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["deployments"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteApplicationExecutableDeployment(int id, int deploymentId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "deployments", deploymentId]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<IEnumerable<ApplicationExecutableTaskModel>> GetApplicationExecutableTasks(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "tasks"]);
            return GetAsync<IEnumerable<ApplicationExecutableTaskModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateApplicationExecutableTask(int id, ApplicationExecutableTaskModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "tasks"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateApplicationExecutableTask(ApplicationExecutableTaskModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["tasks"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteApplicationExecutableTask(int id, int taskId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "tasks", taskId]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<IEnumerable<ApplicationExecutableLicenseModel>> GetApplicationExecutableLicenses(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "licenses"]);
            return GetAsync<IEnumerable<ApplicationExecutableLicenseModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateApplicationExecutableLicense(int id, ApplicationExecutableLicenseModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "licenses"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateApplicationExecutableLicense(ApplicationExecutableLicenseModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["licenses"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteApplicationExecutableLicense(int id, int licenseId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "licenses", licenseId]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<IEnumerable<ApplicationExecutableCdImageModel>> GetApplicationExecutableCdImages(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "cdimages"]);
            return GetAsync<IEnumerable<ApplicationExecutableCdImageModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateApplicationExecutableCdImage(int id, ApplicationExecutableCdImageModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "cdimages"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateApplicationExecutableCdImage(ApplicationExecutableCdImageModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["cdimages"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteApplicationExecutableCdImage(int id, int cdImageId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "cdimages", cdImageId]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<ApplicationExecutableModelImage> GetApplicationExecutableImage(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "image"]);
            return GetAsync<ApplicationExecutableModelImage>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UpdateApplicationExecutableImage(int id, ApplicationExecutableModelImage image, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "image"]);
            return PutAsync<UpdateResult>(parameters, image, cancellationToken);
        }

        public Task<CreateResult> Duplicate(int id, ApplicationExecutableModelDuplicate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "duplicate"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
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
    }
}
