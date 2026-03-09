using Gizmo.Extensibility.Abstractions;
using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/integrations")]
    public sealed class IntegrationsWebApiClient : WebApiClientBase
    {
        public IntegrationsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<IntegrationModel>> GetAsync(IntegrationsFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<IntegrationModel>>(parameters, ct);
        }

        public Task<IntegrationModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<IntegrationModel>(parameters, ct);
        }

        public Task<IReadOnlyList<IntegrationTypeModel>> GetTypesAsync(CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "types" });
            return GetAsync<IReadOnlyList<IntegrationTypeModel>>(parameters, ct);
        }

        public Task<IReadOnlyList<ModuleConfigSectionMetadata>> GetConfigSchemaAsync(Guid typeGuid, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "types", typeGuid, "config-schema" });
            return GetAsync<IReadOnlyList<ModuleConfigSectionMetadata>>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(IntegrationModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(int id, IntegrationModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateConfigAsync(int id, IntegrationConfigUpdateModel model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "config" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }
    }
}
