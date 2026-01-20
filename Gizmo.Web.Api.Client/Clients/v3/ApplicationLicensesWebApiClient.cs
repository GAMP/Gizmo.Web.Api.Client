using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/applicationlicenses")]
    public sealed class ApplicationLicensesWebApiClient : WebApiClientBase
    {
        public ApplicationLicensesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<ApplicationLicenseModel>> GetAsync(ApplicationLicensesFilter filter, CancellationToken cancellation = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ApplicationLicenseModel>>(parameters, cancellation);
        }

        public Task<ApplicationLicenseModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ApplicationLicenseModel>(parameters, cancellationToken);
        }

        public Task<IEnumerable<ApplicationLicenseKey>> KeysAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "keys"]);
            return GetAsync<IEnumerable<ApplicationLicenseKey>>(parameters, cancellationToken);
        }

        public Task<ApplicationLicenseKey> KeyAsync(int keyId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["keys", keyId]);
            return GetAsync<ApplicationLicenseKey>(parameters, cancellationToken);
        }

        public Task<string> KeyDisplayValue(Guid plugin, IDictionary<string, string> keyValues, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([plugin.ToString(), "keys"], keyValues);
            return GetAsync<string>(parameters, cancellationToken);
        }

        public Task<IEnumerable<LicensePluginMetadataModel>> MetaDataAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["metadata"]);
            return GetAsync<IEnumerable<LicensePluginMetadataModel>>(parameters, cancellationToken);
        }
    }
}
