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

        public Task<HostsReportModel> HostsAsync(HostsReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["hosts"], parametersModel);
            return GetAsync<HostsReportModel>(parameters, cancellationToken);
        }

        public Task<UsersReportModel> UsersAsync(UsersReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["users"], parametersModel);
            return GetAsync<UsersReportModel>(parameters, cancellationToken);
        }

        public Task<UserReportModel> UserAsync(UserReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["user"], parametersModel);
            return GetAsync<UserReportModel>(parameters, cancellationToken);
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

        public Task<TransactionsReportModel> TransactionsAsync(TransactionReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["transactions"], parametersModel);
            return GetAsync<TransactionsReportModel>(parameters, cancellationToken);
        }

        public Task<ShiftsReportModel> ShiftsAsync(ShiftsReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["shifts"], parametersModel);
            return GetAsync<ShiftsReportModel>(parameters, cancellationToken);
        }

        public Task<AssetsReportModel> AssetsAsync(AssetsReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["assets"], parametersModel);
            return GetAsync<AssetsReportModel>(parameters, cancellationToken);
        }

        public Task<InvoicesReportModel> InvoicesAsync(InvoicesReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["invoices"], parametersModel);
            return GetAsync<InvoicesReportModel>(parameters, cancellationToken);
        }

        public Task<ZLogReportModel> ZLogAsync(ZLogReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["zlog"], parametersModel);
            return GetAsync<ZLogReportModel>(parameters, cancellationToken);
        }

        public Task<ApplicationsReportModel> ApplicationsAsync(ApplicationsReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["applications"], parametersModel);
            return GetAsync<ApplicationsReportModel>(parameters, cancellationToken);
        }

        public Task<SessionsReportModel> SessionsAsync(SessionsReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["sessions"], parametersModel);
            return GetAsync<SessionsReportModel>(parameters, cancellationToken);
        }

        public Task<LicensesReportModel> LicensesAsync(LicensesReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["licenses"], parametersModel);
            return GetAsync<LicensesReportModel>(parameters, cancellationToken);
        }

        public Task<OrdersReportModel> OrdersAsync(OrdersReportParametersModel parametersModel, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["orders"], parametersModel);
            return GetAsync<OrdersReportModel>(parameters, cancellationToken);
        }
    }
}
