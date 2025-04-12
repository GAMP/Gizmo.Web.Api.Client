using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/mappings")]
    public sealed class MappingsWebApiClient : WebApiClientBase
    {
        public MappingsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<MappingModel>> GetAsync(MappingsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<MappingModel>>(parameters, cancellationToken);
        }

        public Task<MappingModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<MappingModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(VirtualDriveMappingCreateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["virtualDrive"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(VirtualDriveMappingUpdateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["virtualDrive"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(VirtualFolderMappingCreateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["virtualFolder"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(NetworkDriveMappingCreateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["virtualFolder"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(NetworkDriveMappingUpdateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["networkDrive"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(NetworkDriveMappingUpdateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["networkDrive"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<ExistResult> MountPointExistAsync(string mountPoint, CancellationToken cancellationToken)
        {
            var parameters = new UriParameters(["mountpoint", mountPoint, "exist"]);
            return GetAsync<ExistResult>(parameters, cancellationToken);
        }
    }
}
