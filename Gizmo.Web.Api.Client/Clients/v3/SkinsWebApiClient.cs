using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/skins")]
    public sealed class SkinsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public SkinsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<IEnumerable<SkinModel>> GetAsync(CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return GetAsync<IEnumerable<SkinModel>>(parameters, ct);
        }

        #endregion
    }
}
