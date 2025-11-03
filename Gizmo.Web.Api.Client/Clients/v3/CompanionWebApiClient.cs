using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/companions")]
    public sealed class CompanionWebApiClient : WebApiClientBase
    {
        public CompanionWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<CompanionModel>> GetAsync(CompanionFilterModel filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<CompanionModel>>(parameters, ct);
        }

        public Task<CompanionModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<CompanionModel>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(CompanionModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(CompanionModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<IEnumerable<CompanionConnectionInfoModel>> ConnectionsAsync(CancellationToken ct = default)
        {
            var parameters = new UriParameters(["connections"]);
            return GetAsync<IEnumerable<CompanionConnectionInfoModel>>(parameters, ct);
        }

        public async Task OpenCashDrawerAsync(CancellationToken cancellationToken)
        {
            var parameters = new UriParameters(["cashdrawer", "open"]);
            await PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public async Task PrinterXReportAsync(CancellationToken cancellationToken)
        {
            var parameters = new UriParameters(["printer", "x-report"]);
            await PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public async Task PrinterXReportAsync(Guid companionGuid, int? deviceNumber, CancellationToken cancellationToken)
        {
            var queryParameters = deviceNumber.HasValue ? new Dictionary<string, string> { { nameof(deviceNumber), deviceNumber.Value.ToString() } } : [];
            var parameters = new UriParameters([companionGuid, "printer", "x-report"], queryParameters);
            await PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public async Task TerminalXReportAsync(CancellationToken cancellationToken)
        {
            var parameters = new UriParameters(["terminal", "x-report"]);
            await PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public async Task TerminalXReportAsync(Guid companionGuid, int? deviceNumber, CancellationToken cancellationToken)
        {
            var queryParameters = deviceNumber.HasValue ? new Dictionary<string, string> { { nameof(deviceNumber), deviceNumber.Value.ToString() } } : [];
            var parameters = new UriParameters([companionGuid, "terminal", "x-report"], queryParameters);
            await PostAsync<UpdateResult>(parameters, null, cancellationToken);
        }
    }
}
