using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/applicationcategories")]
    public sealed class ApplicationCategoriesWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationCategoriesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS

        public Task<ApplicationCategoryModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ApplicationCategoryModel>(parameters, ct);
        }

        public Task<PagedList<ApplicationCategoryModel>> GetAsync(ApplicationCategoriesFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ApplicationCategoryModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(ApplicationCategoryModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(ApplicationCategoryModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<ApplicationCategoryDeleteResultModel> DeleteAsync(int id, ApplicationCategoryDeleteOptionsModel options, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id], options);
            return DeleteAsync<ApplicationCategoryDeleteResultModel>(parameters, ct);
        }

        #endregion
    }
}
