using Gizmo.Web.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/users")]
    public class UsersWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        
        public UsersWebApiClient(HttpClient client) : base(client)
        {

        } 

        #endregion

        public Task<PagedList<Product>> GetAsync()
        {
            return GetAsync<PagedList<Product>>(GetRequestRoutePath(), default);
        }
    }
}
