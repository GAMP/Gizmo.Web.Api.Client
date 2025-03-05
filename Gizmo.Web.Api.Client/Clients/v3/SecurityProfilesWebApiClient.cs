using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/securityprofiles")]
    public sealed class SecurityProfilesWebApiClient : WebApiClientBase
    {
        public SecurityProfilesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<SecurityProfileModel>> GetAsync(SecurityProfilesFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<SecurityProfileModel>>(parameters, cancellationToken);
        }

        public Task<SecurityProfileModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<SecurityProfileModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(SecurityProfileModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(SecurityProfileModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<IEnumerable<SecurityProfileRestrictionModel>> RestrictionsAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "restrictions"]);
            return GetAsync<IEnumerable<SecurityProfileRestrictionModel>>(parameters, cancellationToken);
        }

        public Task<IEnumerable<SecurityProfilePolicyModel>> PoliciesAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "policies"]);
            return GetAsync<IEnumerable<SecurityProfilePolicyModel>>(parameters, cancellationToken);
        }

        public Task<SecurityProfilePolicesMetadataModel> PoliciesMetadataAsync(CancellationToken cancellationToken)
        {
            var parameters = new UriParameters(["policies", "metadata"]);
            return GetAsync<SecurityProfilePolicesMetadataModel>(parameters, cancellationToken);
        }
    }
}
