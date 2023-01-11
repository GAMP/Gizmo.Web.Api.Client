using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
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

        public Task<PagedList<ApplicationPersonalFileModel>> GetAsync(ApplicationPersonalFilesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ApplicationPersonalFileModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationPersonalFileModelCreate applicationPersonalFileModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), applicationPersonalFileModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationPersonalFileModelUpdate applicationPersonalFileModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), applicationPersonalFileModelUpdate, ct);
        }

        public Task<ApplicationPersonalFileModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationPersonalFileModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
        
        #endregion
    }
}
