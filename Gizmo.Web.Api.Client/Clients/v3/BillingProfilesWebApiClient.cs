using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/billingprofiles")]
    public sealed class BillingProfilesWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public BillingProfilesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : 
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<BillingProfileModel>> GetAsync(BillingProfilesFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<BillingProfileModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(BillingProfileModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(BillingProfileModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<BillingProfileModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<BillingProfileModel>(parameters, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<IEnumerable<BillingProfileModel>> GetBillingProfilesRates(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "rates" });
            return GetAsync<IEnumerable<BillingProfileModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateBillingProfilesRate(int id, BillingProfileRateModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "rates" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateBillingProfileRate(BillingProfileRateModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "rates" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteBillingProfileRate(int id, int billingProfileRateId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "rates", billingProfileRateId });
            return DeleteAsync<DeleteResult>(parameters, ct);
        } 

        #endregion
    }
}
