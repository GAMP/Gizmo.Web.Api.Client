using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using System.Runtime.Serialization;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("auth/token")]
    public class AuthenticationWebApiClient:WebApiClientBase
    {
        #region CONSTRUCTOR
       
        public AuthenticationWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        public Task<AuthToken> GetToken(TestUser user ,CancellationToken ct = default)
        {
            return GetAsync<AuthToken>(user, ct);
        }      
    }


    //TODO: When we decide what todo with the serialization issue, this needs to be refactored to models
    [Serializable]
    [DataContract]
    public class AuthToken
    {
        public string Token { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }

    //TODO: When we decide what todo with the serialization issue, this needs to be refactored to models
    [Serializable]
    [DataContract]
    public class TestUser : IUrlQueryParameters
    {
        public string Username { get; set; } = "admin";
        public string Password { get; set; } = "admin";
    }
}
