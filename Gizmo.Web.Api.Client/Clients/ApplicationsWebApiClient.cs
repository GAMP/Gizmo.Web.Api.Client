using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/applications")]
    public class ApplicationsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ApplicationModel>> GetAsync(ApplicationsFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ApplicationModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<ApplicationModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ApplicationModel>(parameters, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<ApplicationModelImage> GetApplicationImage(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] {id, "image" });
            return GetAsync<ApplicationModelImage>(parameters, ct);
        }

        public Task<UpdateResult> UpdateApplicationImage(int id, ApplicationModelImage model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "image" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        } 

        #endregion
    }
}
