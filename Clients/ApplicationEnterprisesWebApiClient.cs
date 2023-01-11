using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/applicationenterprises")]
    public class ApplicationEnterprisesWebApiClient:WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationEnterprisesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ApplicationEnterpriseModel>> GetAsync(ApplicationEnterprisesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ApplicationEnterpriseModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationEnterpriseModelCreate applicationEnterpriseModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), applicationEnterpriseModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationEnterpriseModelUpdate applicationEnterpriseModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), applicationEnterpriseModelUpdate, ct);
        }

        public Task<ApplicationEnterpriseModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationEnterpriseModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        } 
        
        #endregion
    }
}
