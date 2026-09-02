using System.Net.Http;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Threading;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/verificationcodes")]
    public sealed class VerificationCodesWebApiClient : WebApiClientBase
    {
        public VerificationCodesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<VerificationCodeModel>> GetAsync(VerificationCodesFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<VerificationCodeModel>>(parameters, cancellationToken);
        }
    }
}
