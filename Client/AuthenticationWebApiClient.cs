using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using System.Runtime.Serialization;

namespace Gizmo.Web.Api.Client.Client
{
    [WebApiRoute("auth/token")]
    public class AuthenticationWebApiClient:WebApiClientBase
    {
        #region CONSTRUCTOR
       
        public AuthenticationWebApiClient(HttpClient client):base(client)
        {

        }
        #endregion

        public Task<AuthToken> GetToken(TestUser user ,CancellationToken ct = default)
        {
            var b = GetResultAsync<AuthToken>(CreateRequestUrl(user));
            var c = b.GetAwaiter().GetResult();
            var x = GetAsync<AuthToken>(user, ct);
            return b;

        }      
    }


    //TODO: When we decide what todo with the serialization issue, this needs to be refactored to models
    [Serializable]
    [DataContract]
    public class AuthToken
    {
        public string token { get; set; }
        public string refreshToken { get; set; }
    }

    //TODO: When we decide what todo with the serialization issue, this needs to be refactored to models
    [Serializable]
    [DataContract]
    public class TestUser : IUrlQueryParameters
    {
        [DataMember]
        public string username { get; set; } = "admin";
        [DataMember]
        public string password { get; set; } = "admin";
    }
}
