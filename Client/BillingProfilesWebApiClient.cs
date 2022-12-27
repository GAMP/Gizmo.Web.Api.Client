using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Models.API.Request;
using Gizmo.Web.Api.Models.Models.API.Request.BillingProfile;
using Gizmo.Web.Api.Models.Models.API.Request.BillingProfile.Rate.Model;
using Microsoft.Extensions.Options;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/billingprofiles")]
    public class BillingProfilesWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public BillingProfilesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : 
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<BillingProfile>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<BillingProfile>> GetAsync(BillingProfilesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<BillingProfile>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(BillingProfileModelCreate billingProfileModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), billingProfileModelCreate, ct);
        }

        public Task<UpdateResult> UpdateAsync(BillingProfileModelUpdate billingProfileModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), billingProfileModelUpdate, ct);
        }

        public Task<BillingProfile> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<BillingProfile>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<IEnumerable<BillingProfile>> GetBillingProfilesRates(int id, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<BillingProfile>>(CreateRequestUrlWithRouteParameters($"{id}/rates"), ct);
        }

        public Task<CreateResult> CreateBillingProfilesRate(int id, BillingProfileRateModelCreate billingProfileRateModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"{id}/rates"), billingProfileRateModelCreate, ct);
        }

        public Task<UpdateResult> UpdateBillingProfileRate(BillingProfileRateModelUpdate billingProfileRateModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"rates"), billingProfileRateModelUpdate, ct);
        }

        public Task<DeleteResult> DeleteBillingProfileRate(int id, int billingProfileRateId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}/rates/{billingProfileRateId}"), ct);
        } 

        #endregion
    }
}
