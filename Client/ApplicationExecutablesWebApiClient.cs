using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/applicationexecutables")]
    public class ApplicationExecutablesWebApiClient : WebApiClientBase
    {
        public ApplicationExecutablesWebApiClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<PagedList<ApplicationExecutable>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<ApplicationExecutable>> GetAsync(ApplicationExecutablesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ApplicationExecutable>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationExecutableModelCreate applicationExecutableModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), applicationExecutableModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationExecutableModelUpdate applicationExecutableModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), applicationExecutableModelUpdate, ct);
        }

        public Task<ApplicationExecutable> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationExecutable>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<IEnumerable<ApplicationExecutablePersonalFile>> GetApplicationExecutablePersonalFiles(int id, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<ApplicationExecutablePersonalFile>>(CreateRequestUrlWithRouteParameters($"{id}/personalfiles"), ct);
        }

        public Task<CreateResult> CreateApplicationExecutablePersonalFile(int id, ApplicationExecutablePersonalFileModelCreate applicationExecutablePersonalFileModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"{id}/personalfiles"), applicationExecutablePersonalFileModelCreate, ct);
        }

        public Task<UpdateResult> UpdateApplicationExecutablePersonalFile(ApplicationExecutablePersonalFileModelUpdate applicationExecutablePersonalFileModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"personalfiles"), applicationExecutablePersonalFileModelUpdate, ct);
        }

        public Task<DeleteResult> DeleteApplicationExecutablePersonalFile(int id, int personalFileId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}/personalfiles/{personalFileId}"), ct);
        }

        public Task<IEnumerable<ApplicationExecutableDeployment>> GetApplicationExecutableDeployments(int id, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<ApplicationExecutableDeployment>>(CreateRequestUrlWithRouteParameters($"{id}/deployments"), ct);
        }

        public Task<CreateResult> CreateApplicationExecutableDeployment(int id, ApplicationExecutableDeploymentModelCreate applicationExecutableDeploymentModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"{id}/deployments"), applicationExecutableDeploymentModelCreate, ct);
        }

        public Task<UpdateResult> UpdateApplicationExecutableDeployment(ApplicationExecutableDeploymentModelUpdate applicationExecutableDeploymentModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"deployments"), applicationExecutableDeploymentModelUpdate, ct);
        }

        public Task<DeleteResult> DeleteApplicationExecutableDeployment(int id, int deploymentId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}/deployments/{deploymentId}"), ct);
        }

        public Task<IEnumerable<ApplicationExecutableTask>> GetApplicationExecutableTasks(int id, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<ApplicationExecutableTask>>(CreateRequestUrlWithRouteParameters($"{id}/tasks"), ct);
        }

        public Task<CreateResult> CreateApplicationExecutableTask(int id, ApplicationExecutableTaskModelCreate applicationExecutableTaskModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"{id}/tasks"), applicationExecutableTaskModelCreate, ct);
        }

        public Task<UpdateResult> UpdateApplicationExecutableTask(ApplicationExecutableTaskModelUpdate applicationExecutableTaskModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"tasks"), applicationExecutableTaskModelUpdate, ct);
        }

        public Task<DeleteResult> DeleteApplicationExecutableTask(int id, int taskId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}/tasks/{taskId}"), ct);
        }

        public Task<IEnumerable<ApplicationExecutableLicense>> GetApplicationExecutableLicenses(int id, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<ApplicationExecutableLicense>>(CreateRequestUrlWithRouteParameters($"{id}/licenses"), ct);
        }

        public Task<CreateResult> CreateApplicationExecutableLicense(int id, ApplicationExecutableLicenseModelCreate applicationExecutableLicenseModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"{id}/licenses"), applicationExecutableLicenseModelCreate, ct);
        }

        public Task<UpdateResult> UpdateApplicationExecutableLicense(ApplicationExecutableLicenseModelUpdate applicationExecutableLicenseModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"licenses"), applicationExecutableLicenseModelUpdate, ct);
        }

        public Task<DeleteResult> DeleteApplicationExecutableLicense(int id, int licenseId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}/licenses/{licenseId}"), ct);
        }

        public Task<IEnumerable<ApplicationExecutableCdImage>> GetApplicationExecutableCdImages(int id, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<ApplicationExecutableCdImage>>(CreateRequestUrlWithRouteParameters($"{id}/cdimages"), ct);
        }

        public Task<CreateResult> CreateApplicationExecutableCdImage(int id, ApplicationExecutableCdImageModelCreate applicationExecutableCdImageModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"{id}/cdimages"), applicationExecutableCdImageModelCreate, ct);
        }

        public Task<UpdateResult> UpdateApplicationExecutableCdImage(ApplicationExecutableCdImageModelUpdate applicationExecutableCdImageModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"cdimages"), applicationExecutableCdImageModelUpdate, ct);
        }

        public Task<DeleteResult> DeleteApplicationExecutableCdImage(int id, int cdImageId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}/cdimages/{cdImageId}"), ct);
        }

        public Task<ApplicationExecutableImage> GetApplicationExecutableImage(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationExecutableImage>(CreateRequestUrlWithRouteParameters($"{id}/image"), ct);
        }

        public Task<UpdateResult> UpdateApplicationExecutableImage(int id, ApplicationExecutableImage image, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"{id}"), image, ct);
        }
    }
}