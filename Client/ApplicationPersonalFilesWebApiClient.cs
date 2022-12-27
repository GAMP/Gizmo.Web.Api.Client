using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Models.API.Request;
using Gizmo.Web.Api.Models.Models.API.Request.Application.PersonalFile.Model;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/applicationpersonalfiles")]
    public class ApplicationPersonalFilesWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationPersonalFilesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ApplicationPersonalFile>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<ApplicationPersonalFile>> GetAsync(ApplicationPersonalFilesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ApplicationPersonalFile>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationPersonalFileModelCreate applicationPersonalFileModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), applicationPersonalFileModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationPersonalFileModelUpdate applicationPersonalFileModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), applicationPersonalFileModelUpdate, ct);
        }

        public Task<ApplicationPersonalFile> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationPersonalFile>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
        
        #endregion
    }
}
