using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/promotions")]
    public sealed class PromotionsWebApiClient : WebApiClientBase
    {
        public PromotionsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
           base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<PromotionModel>> GetAsync(PromotionFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<PromotionModel>>(parameters, cancellationToken);
        }

        public Task<PromotionModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<PromotionModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(PromotionCreateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(int id, PromotionUpdateModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<IEnumerable<PromotionCodeModel>> PromotionCodesAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "codes"]);
            return GetAsync<IEnumerable<PromotionCodeModel>>(parameters, cancellationToken);
        }

        public Task<PromotionCodeModel> PromotionCodeAsync(int promoCodeId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["codes", promoCodeId]);
            return GetAsync<PromotionCodeModel>(parameters, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UndeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "undelete"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<DeleteResult> EnableAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "enable"]);
            return PutAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<UpdateResult> DisableAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "disable"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public async Task<Stream> ExportAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "export"]);
            var memoryStream = new MemoryStream();
            await GetContentCopyAsync(parameters, memoryStream, cancellationToken).ConfigureAwait(false);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream;
        }
    }
}
