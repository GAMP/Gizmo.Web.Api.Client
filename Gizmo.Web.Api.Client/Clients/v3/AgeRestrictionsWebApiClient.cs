using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/agerestrictions")]
    public sealed class AgeRestrictionsWebApiClient : WebApiClientBase
    {
        public AgeRestrictionsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<AgeRestrictionModel>> GetAsync(AgeRestrictionsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<AgeRestrictionModel>>(parameters, cancellationToken);
        }

        public Task<AgeRestrictionModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<AgeRestrictionModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(AgeRestrictionLoginModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["login"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }
    }
}
