﻿using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/reports")]
    public sealed class ReportsWebApiClient : WebApiClientBase
    {
        public ReportsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<OverviewReportModel> OverviewAsync(OverviewReportParametersModel parametersModel, CancellationToken cancellationToken =default)
        {
            var parameters = new UriParameters(parametersModel);
            return GetAsync<OverviewReportModel>(parameters, cancellationToken);
        }
    }
}
