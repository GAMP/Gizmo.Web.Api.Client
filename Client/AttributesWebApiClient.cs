using Gizmo.Web.Api.Models;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("api/v2/attributes")]
    public class AttributesWebApiClient:WebApiClientBase
    {
        #region CONSTRUCTOR
        public AttributesWebApiClient(HttpClient client) : base(client)
        {

        }
        #endregion
        public Task<PagedList<Attribute>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<Attribute>> GetAsync(AttributesFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<Attribute>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(Attribute attribute, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(attribute, ct);
        }

        public Task<CreateResult> PutAsync(Attribute attribute, CancellationToken ct = default)
        {
            return PutAsync<CreateResult>(attribute, ct);
        }

        public Task<Attribute> FindAsync(int id, CancellationToken ct = default)
        {            
            return GetAsync<Attribute>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<Attribute> DeleteAsync(int id, CancellationToken ct = default)
        {           
            return DeleteAsync<Attribute>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
    }
}
