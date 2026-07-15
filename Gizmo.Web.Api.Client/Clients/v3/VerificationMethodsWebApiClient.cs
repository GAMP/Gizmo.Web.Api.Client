using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/verificationmethods")]
    public sealed class VerificationMethodsWebApiClient : WebApiClientBase
    {
        public VerificationMethodsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<VerificationMethodModel>> GetAsync(VerificationMethodsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<VerificationMethodModel>>(parameters, cancellationToken);
        }

        public Task<VerificationMethodModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<VerificationMethodModel>(parameters, cancellationToken);
        }

        /// <summary>
        /// Gets the integrations offerable in the specified context's method chain, each with the
        /// mechanisms it can still be added with — pairs already configured in the chain are excluded.
        /// </summary>
        /// <param name="context">Verification context whose chain is being composed.</param>
        /// <param name="capabilityGuid">Optional — restrict to integrations offerable with this mechanism.</param>
        public Task<IReadOnlyList<EligibleIntegrationModel>> GetEligibleIntegrationsAsync(VerificationContext context, Guid? capabilityGuid = null, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, string>
            {
                ["context"] = context.ToString(),
            };

            if (capabilityGuid.HasValue)
                query["capabilityGuid"] = capabilityGuid.Value.ToString();

            var parameters = new UriParameters(new object[] { "integrations" }, query);
            return GetAsync<IReadOnlyList<EligibleIntegrationModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(VerificationMethodModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(int id, VerificationMethodModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        /// <summary>
        /// Applies a bulk display order — each listed entry receives its position index as display order.
        /// </summary>
        public Task<UpdateResult> UpdateOrderAsync(VerificationMethodsOrderModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(new object[] { "order" });
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }
    }
}
