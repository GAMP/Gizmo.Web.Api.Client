﻿using Gizmo.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/productgroups")]
    public class ProductGroupsWebApiClient:WebApiClientBase
    {
        #region CONSTRUCTOR
        public ProductGroupsWebApiClient(HttpClient client) : base(client)
        {

        }
        #endregion

        public Task<PagedList<ProductGroup>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<ProductGroup>> GetAsync(ProductGroupsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ProductGroup>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ProductGroup productGroup, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(productGroup, ct);
        }

        public Task<CreateResult> PutAsync(ProductGroup productGroup, CancellationToken ct = default)
        {
            return PutAsync<CreateResult>(productGroup, ct);
        }

        public Task<ProductGroup> FindAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ProductGroup>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<ProductGroup> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<ProductGroup>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
    }
}
