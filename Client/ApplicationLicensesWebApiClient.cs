using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/applicationlicenses")]
    public class ApplicationLicensesWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationLicensesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        } 
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ApplicationLicense>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<ApplicationLicense>> GetAsync(ApplicationLicensesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ApplicationLicense>>(filter, ct);
        }

        public Task<ApplicationLicense> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ApplicationLicense>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        } 

        #endregion
    }
}
