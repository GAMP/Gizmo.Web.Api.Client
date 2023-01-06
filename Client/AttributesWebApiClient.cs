using Gizmo.Web.Api.Models;

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

        public Task<PagedList<AttributeModel>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<AttributeModel>> GetAsync(AttributesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<AttributeModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(AttributeModelCreate attribute, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), attribute, ct);
        }

        public Task<UpdateResult> UpdateAsync(AttributeModelUpdate attribute, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), attribute, ct);
        }

        public Task<AttributeModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<AttributeModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion
    }
}
