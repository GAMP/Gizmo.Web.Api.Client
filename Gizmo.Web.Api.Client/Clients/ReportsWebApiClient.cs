using System.Net.Http;
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

        public Task<OverviewReportModel> OverviewAsync(OverviewReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["overview"], parametersModel);
            return GetAsync<OverviewReportModel>(parameters, cancellationToken);
        }

        public Task<FinancialReportModel> FinancialAsync(FinancialReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["financial"], parametersModel);
            return GetAsync<FinancialReportModel>(parameters, cancellationToken);
        }

        public Task<HostUsageReportModel> HostUsageAsync(HostUsageReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["hostusage"], parametersModel);
            return GetAsync<HostUsageReportModel>(parameters, cancellationToken);
        }

        public Task<TopUsersReportModel> TopUsersAsync(TopUsersReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["topusers"], parametersModel);
            return GetAsync<TopUsersReportModel>(parameters, cancellationToken);
        }

        public Task<UserReportModel> UserAsync(UserReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user"], parametersModel);
            return GetAsync<UserReportModel>(parameters, cancellationToken);
        }

        public Task<ProductReportModel> ProductAsync(ProductReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["product"], parametersModel);
            return GetAsync<ProductReportModel>(parameters, cancellationToken);
        }

        public Task<ProductsReportModel> ProductsAsync(ProductsReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["products"], parametersModel);
            return GetAsync<ProductsReportModel>(parameters, cancellationToken);
        }

        public Task<ProductsLogReportModel> ProductsLogAsync(ProductsLogReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["productslog"], parametersModel);
            return GetAsync<ProductsLogReportModel>(parameters, cancellationToken);
        }

        public Task<StockReportModel> StockAsync(StockReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["stock"], parametersModel);
            return GetAsync<StockReportModel>(parameters, cancellationToken);
        }

        public Task<TransactionsLogReportModel> TransactionsLogAsync(TransactionsLogReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["transactionslog"], parametersModel);
            return GetAsync<TransactionsLogReportModel>(parameters, cancellationToken);
        }

        public Task<ShiftsLogReportModel> ShiftsLogAsync(ShiftsLogReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["shiftslog"], parametersModel);
            return GetAsync<ShiftsLogReportModel>(parameters, cancellationToken);
        }

        public Task<AssetsLogReportModel> AssetsLogAsync(AssetsLogReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["assetslog"], parametersModel);
            return GetAsync<AssetsLogReportModel>(parameters, cancellationToken);
        }

        public Task<InvoiceReportModel> InvoiceAsync(InvoiceReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["invoice"], parametersModel);
            return GetAsync<InvoiceReportModel>(parameters, cancellationToken);
        }

        public Task<InvoicesLogReportModel> InvoicesLogAsync(InvoicesLogReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["invoiceslog"], parametersModel);
            return GetAsync<InvoicesLogReportModel>(parameters, cancellationToken);
        }

        public Task<ZLogReportModel> ZLogAsync(ZLogReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["zlog"], parametersModel);
            return GetAsync<ZLogReportModel>(parameters, cancellationToken);
        }

        public Task<ZReportModel> ZAsync(ZReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["z"], parametersModel);
            return GetAsync<ZReportModel>(parameters, cancellationToken);
        }

        public Task<ApplicationReportModel> ApplicationAsync(ApplicationReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["application"], parametersModel);
            return GetAsync<ApplicationReportModel>(parameters, cancellationToken);
        }

        public Task<ApplicationsReportModel> ApplicationsAsync(ApplicationsReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["applications"], parametersModel);
            return GetAsync<ApplicationsReportModel>(parameters, cancellationToken);
        }

        public Task<SessionsLogReportModel> SessionsLogAsync(SessionsLogReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["sessionslog"], parametersModel);
            return GetAsync<SessionsLogReportModel>(parameters, cancellationToken);
        }

        public Task<LicenseReportModel> LicenseAsync(LicenseReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["license"], parametersModel);
            return GetAsync<LicenseReportModel>(parameters, cancellationToken);
        }

        public Task<LicensesReportModel> LicensesAsync(LicensesReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["licenses"], parametersModel);
            return GetAsync<LicensesReportModel>(parameters, cancellationToken);
        }

        public Task<OrdersLogReportModel> OrdersLogAsync(OrdersLogReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["orderslog"], parametersModel);
            return GetAsync<OrdersLogReportModel>(parameters, cancellationToken);
        }

        public Task<OrdersStatisticsReportModel> OrdersStatisticsAsync(OrdersStatisticsReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["ordersstatistics"], parametersModel);
            return GetAsync<OrdersStatisticsReportModel>(parameters, cancellationToken);
        }
    }
}
