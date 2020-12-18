using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/registers")]
    public class RegisterWebApiClient:WebApiClientBase
    {
        #region CONSTRUCTOR
        public RegisterWebApiClient(HttpClient client):base(client)
        {

        }
        #endregion

        public Task<PagedList<Register>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<Register>> GetAsync(RegistersFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<Register>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(RegisterModelCreate registerModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), registerModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(RegisterModelUpdate registerModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), registerModelUpdate, ct);
        }
         
        public Task<Register> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<Register>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
    }
}
