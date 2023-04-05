using System;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Abstractions;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("auth/token")]
    public class AuthenticationWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR

        public AuthenticationWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {

        }
        #endregion

        public Task<AuthToken> GetToken(AuthTokenUserData user, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "token" }, user);
            return GetAsync<AuthToken>(parameters, ct);
        }
        public Task<AuthToken> RefreshToken(AuthToken token, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "refreshtoken" }, token);
            return GetAsync<AuthToken>(parameters, ct);
        }
    }

    //TODO: When we decide what todo with the serialization issue, this needs to be refactored to models
    [Serializable]
    [DataContract]
    public class AuthToken : IUriParametersQuery
    {
        public string Token { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }

    //TODO: When we decide what todo with the serialization issue, this needs to be refactored to models
    [Serializable]
    [DataContract]
    public class AuthTokenUserData : IUriParametersQuery
    {
        public string Username { get; set; } = "admin";
        public string Password { get; set; } = "admin";
    }
}
