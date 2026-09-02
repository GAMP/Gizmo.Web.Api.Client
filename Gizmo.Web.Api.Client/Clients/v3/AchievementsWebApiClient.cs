using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/achievements")]
    public sealed class AchievementsWebApiClient : WebApiClientBase
    {
        public AchievementsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<AchievementModel>> GetAsync(AchievementsFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<AchievementModel>>(parameters, cancellationToken);
        }

        public Task<AchievementModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<AchievementModel>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(AchievementModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(AchievementModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
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

        public Task<UpdateResult> EnableAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "enable"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<UpdateResult> DisableAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "disable"]);
            return PutAsync<UpdateResult>(parameters, null, cancellationToken);
        }

        public Task<IReadOnlyList<AchievementSignalModel>> GetSignalsAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["signals"]);
            return GetAsync<IReadOnlyList<AchievementSignalModel>>(parameters, cancellationToken);
        }
    }
}
