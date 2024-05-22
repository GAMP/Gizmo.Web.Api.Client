using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IO;

namespace Gizmo.Web.Api.Clients
{
    /// <summary>
    /// Report modules web api client.
    /// </summary>
    [WebApiRoute("api/v3/reportmodules")]
    public sealed class ReportModulesWebApiClient : WebApiClientBase
    {
        private static readonly Type WebClientType = typeof(ReportModulesWebApiClient);
        private static readonly MethodInfo GetMethodInfo = WebClientType.GetMethod(nameof(GetAsync), 1, [typeof(Guid), typeof(IDictionary<string, string>), typeof(CancellationToken)])!;
        private static readonly RecyclableMemoryStreamManager StreamManager = new();

        public ReportModulesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        /// <summary>
        /// Generates report export.
        /// </summary>
        /// <param name="guid">Report module id.</param>
        /// <param name="reportPackModel">Report model pack.</param>
        /// <param name="format">Export format (pdf) by default.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Export stream.</returns>
        public async Task<Stream> ExportAsync(Guid guid, IReportPackModel reportPackModel, string format = "pdf", CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([guid.ToString(), "export"], new Dictionary<string, string>() { { "format", format } });

            //create pooled memory stream
            var memoryStream = StreamManager.GetStream();

            //call the web api and copy the response stream
            await PostContentCopyAsync(parameters, (object?)reportPackModel, memoryStream, cancellationToken).ConfigureAwait(false);

            //seek to beginning
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream;
        }

        /// <summary>
        /// Generates report.
        /// </summary>
        /// <param name="guid">Report module id.</param>
        /// <param name="resultModelType">Result model type.</param>
        /// <param name="filters">Report filters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Report result model.</returns>
        public async Task<IReportModuleResultModel> GetAsync(Guid guid, Type resultModelType, IDictionary<string, string> filters, CancellationToken cancellationToken = default)
        {
            var genericMethod = GetMethodInfo.MakeGenericMethod(resultModelType);

            //TODO : reflection might be faster than dynamic
            dynamic task = (Task)genericMethod.Invoke(this, new object[] { guid, filters, cancellationToken })!;

            //await for task to complete
            await task;

            return (IReportModuleResultModel)task.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Generates report.
        /// </summary>
        ///<typeparam name="TReportModuleResultModel">Result model type.</typeparam>
        /// <param name="guid">Report module id.</param>
        /// <param name="filters">Report filters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Report result model.</returns>
        public Task<TReportModuleResultModel> GetAsync<TReportModuleResultModel>(Guid guid, IDictionary<string, string> filters, CancellationToken cancellationToken = default)
            where TReportModuleResultModel : IReportModuleResultModel
        {
            var parameters = new UriParameters([guid.ToString()], filters);
            return GetAsync<TReportModuleResultModel>(parameters, cancellationToken);
        }
    }
}
