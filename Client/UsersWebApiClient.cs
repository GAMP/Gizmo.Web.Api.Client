using System.Net.Http;

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
    }
}
