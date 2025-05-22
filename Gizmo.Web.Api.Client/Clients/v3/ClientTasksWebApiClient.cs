using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/clienttasks")]
    public sealed class ClientTasksWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ClientTasksWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ClientTaskModel>> GetAsync(ClientTaskFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ClientTaskModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(ClientTaskCreateModel model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(ClientTaskUpdateModel model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<ClientTaskModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ClientTaskModel>(parameters, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        #endregion
    }
}
