using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/securityprofiles")]
    public sealed class SecurityProfilesWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public SecurityProfilesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<SecurityProfileModel>> GetAsync(SecurityProfilesFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<SecurityProfileModel>>(parameters, ct);
        }

        public Task<SecurityProfileModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<SecurityProfileModel>(parameters, ct);
        }

        #endregion
    }
}
