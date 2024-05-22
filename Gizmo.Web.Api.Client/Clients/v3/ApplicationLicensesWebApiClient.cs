using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/applicationlicenses")]
    public sealed class ApplicationLicensesWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationLicensesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        } 
        #endregion

        #region FUNCTIONS

        public Task<PagedList<ApplicationLicenseModel>> GetAsync(ApplicationLicensesFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ApplicationLicenseModel>>(parameters, ct);
        }

        public Task<ApplicationLicenseModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ApplicationLicenseModel>(parameters, ct);
        } 

        #endregion
    }
}
