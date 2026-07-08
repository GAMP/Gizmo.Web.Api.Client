using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Clients;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.User.Clients
{
    [UnsecureWebApiClient()]
    [WebApiRoute("api/user/v3/validations")]
    public sealed class ValidationsWebApiClient : WebApiClientBase
    {
        public ValidationsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<IReadOnlyList<PhoneCountryModel>> GetPhoneCountriesAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["phone", "countries"]);
            return GetAsync<IReadOnlyList<PhoneCountryModel>>(parameters, cancellationToken);
        }

        public Task<PhoneValidationResultModel> ValidatePhoneAsync(PhoneValidationRequestModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["phone"]);
            return PostAsync<PhoneValidationResultModel>(parameters, model, cancellationToken);
        }
    }
}
