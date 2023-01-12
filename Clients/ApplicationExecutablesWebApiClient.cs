using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/applicationexecutables")]
    public class ApplicationExecutablesWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationExecutablesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ApplicationExecutableModel>> GetAsync(ApplicationExecutablesFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ApplicationExecutableModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationExecutableModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationExecutableModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<ApplicationExecutableModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ApplicationExecutableModel>(parameters, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<IEnumerable<ApplicationExecutablePersonalFileModel>> GetApplicationExecutablePersonalFiles(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "personalfiles" });
            return GetAsync<IEnumerable<ApplicationExecutablePersonalFileModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateApplicationExecutablePersonalFile(int id, ApplicationExecutablePersonalFileModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "personalfiles" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateApplicationExecutablePersonalFile(ApplicationExecutablePersonalFileModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "personalfiles" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteApplicationExecutablePersonalFile(int id, int personalFileId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "personalfiles", personalFileId });
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<IEnumerable<ApplicationExecutableDeploymentModel>> GetApplicationExecutableDeployments(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "deployments" });
            return GetAsync<IEnumerable<ApplicationExecutableDeploymentModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateApplicationExecutableDeployment(int id, ApplicationExecutableDeploymentModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "deployments" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateApplicationExecutableDeployment(ApplicationExecutableDeploymentModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "deployments" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteApplicationExecutableDeployment(int id, int deploymentId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "deployments", deploymentId });
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<IEnumerable<ApplicationExecutableTaskModel>> GetApplicationExecutableTasks(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "tasks" });
            return GetAsync<IEnumerable<ApplicationExecutableTaskModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateApplicationExecutableTask(int id, ApplicationExecutableTaskModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "tasks" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateApplicationExecutableTask(ApplicationExecutableTaskModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "tasks" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteApplicationExecutableTask(int id, int taskId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "tasks", taskId });
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<IEnumerable<ApplicationExecutableLicenseModel>> GetApplicationExecutableLicenses(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "licenses" });
            return GetAsync<IEnumerable<ApplicationExecutableLicenseModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateApplicationExecutableLicense(int id, ApplicationExecutableLicenseModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "licenses" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateApplicationExecutableLicense(ApplicationExecutableLicenseModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "licenses" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteApplicationExecutableLicense(int id, int licenseId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "licenses", licenseId });
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<IEnumerable<ApplicationExecutableCdImageModel>> GetApplicationExecutableCdImages(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "cdimages" });
            return GetAsync<IEnumerable<ApplicationExecutableCdImageModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateApplicationExecutableCdImage(int id, ApplicationExecutableCdImageModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "cdimages" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateApplicationExecutableCdImage(ApplicationExecutableCdImageModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "cdimages" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteApplicationExecutableCdImage(int id, int cdImageId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "cdimages", cdImageId });
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<ApplicationExecutableModelImage> GetApplicationExecutableImage(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "image" });
            return GetAsync<ApplicationExecutableModelImage>(parameters, ct);
        }

        public Task<UpdateResult> UpdateApplicationExecutableImage(int id, ApplicationExecutableModelImage image, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return PutAsync<UpdateResult>(parameters, image, ct);
        } 

        #endregion
    }
}