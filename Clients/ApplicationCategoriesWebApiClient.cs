using Gizmo.Web.Api.Models;
using Gizmo.Web.Api.Models.Abstractions.Models.RequestParameters;

using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/applicationcategories")]
    public class ApplicationCategoriesWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        public ApplicationCategoriesWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }
        #endregion

        #region FUNCTIONS
        public Task<PagedList<ApplicationCategoryModel>> GetAsync(IRequestParameters parameters, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ApplicationCategoryModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(IRequestParameters parameters, ApplicationCategoryModelCreate model, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(IRequestParameters parameters, ApplicationCategoryModelUpdate model, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteAsync(IRequestParameters parameters, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        #endregion
    }
}
