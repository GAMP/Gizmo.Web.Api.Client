using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/registers")]
    public sealed class RegisterWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public RegisterWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<RegisterModel>> GetAsync(RegistersFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<RegisterModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(RegisterModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(RegisterModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<RegisterModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<RegisterModel>(parameters, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<DeleteResult> UndeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id,"undelete"]);
            return PutAsync<DeleteResult>(parameters,null, ct);
        }

        public Task<RegisterModel> CurrentAsync(CancellationToken ct = default)
        {
            var parameters = new UriParameters(new[] { "current" });
            return GetAsync<RegisterModel>(parameters, ct);
        }

        #endregion
    }
}
