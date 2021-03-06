﻿using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/productgroups")]
    public class ProductGroupsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ProductGroupsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        #region FUNCTIONS
        
        public Task<PagedList<ProductGroup>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<ProductGroup>> GetAsync(ProductGroupsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ProductGroup>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ProductGroupModelCreate productGroup, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), productGroup, ct);
        }

        public Task<UpdateResult> UpdateAsync(ProductGroupModelUpdate productGroup, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), productGroup, ct);
        }

        public Task<ProductGroup> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ProductGroup>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        } 

        #endregion
    }
}
