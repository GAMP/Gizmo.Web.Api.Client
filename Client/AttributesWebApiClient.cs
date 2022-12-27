using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Models.API.Request;
using Gizmo.Web.Api.Models.Models.API.Request.Attribute;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/attributes")]
    public class AttributesWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public AttributesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        #region FUNCTIONS

        public Task<PagedList<Attribute>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<Attribute>> GetAsync(AttributesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<Attribute>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(AttributeModelCreate attribute, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), attribute, ct);
        }

        public Task<UpdateResult> UpdateAsync(AttributeModelUpdate attribute, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), attribute, ct);
        }

        public Task<Attribute> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<Attribute>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
