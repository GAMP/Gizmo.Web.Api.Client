﻿using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/applicationgroups")]
    public class ApplicationGroupsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationGroupsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ApplicationGroupModel>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<ApplicationGroupModel>> GetAsync(ApplicationGroupsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ApplicationGroupModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationGroupModelCreate applicationGroupModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), applicationGroupModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationGroupModelUpdate applicationGroupModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), applicationGroupModelUpdate, ct);
        }

        public Task<ApplicationGroupModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationGroupModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        } 

        #endregion
    }
}
