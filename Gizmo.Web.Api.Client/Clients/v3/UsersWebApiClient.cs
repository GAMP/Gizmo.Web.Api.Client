using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/users")]
    public sealed class UsersWebApiClient : WebApiClientBase
    {
        public UsersWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<UserModel>> GetAsync(UsersFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<UserModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateAsync(UserModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateAsync(UserModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<UserModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<UserModel>(parameters, cancellationToken);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<DeleteResult> HardDeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "hard"]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<IEnumerable<UserAttributeModel>> GetUserAttributesAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "attributes"]);
            return GetAsync<IEnumerable<UserAttributeModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateUserAttributeAsync(int id, UserAttributeModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "attributes"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateUserAttributeAsync(UserAttributeModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["attributes"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteUserAttributeAsync(int id, int userAttributeId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "attributes", userAttributeId]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<UserNoteCountModel> GetUserNotesCountAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "notes", "count"]);
            return GetAsync<UserNoteCountModel>(parameters, cancellationToken);
        }

        public Task<PagedList<UserNoteModel>> GetUserNotesAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "notes"]);
            return GetAsync<PagedList<UserNoteModel>>(parameters, cancellationToken);
        }

        public Task<PagedList<UserNoteModel>> GetUserNotesAsync(int id, UserNotesFilter model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "notes"], model);
            return GetAsync<PagedList<UserNoteModel>>(parameters, cancellationToken);
        }

        public Task<CreateResult> CreateUserNoteAsync(int id, UserNoteModelCreate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "notes"]);
            return PostAsync<CreateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateUserNoteAsync(UserNoteModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["notes"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<DeleteResult> DeleteUserNoteAsync(int id, int noteId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "notes", noteId]);
            return DeleteAsync<DeleteResult>(parameters, cancellationToken);
        }

        public Task<UserNoteModel> GetUserNoteByIdAsync(int id, int userNoteId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "notes", userNoteId]);
            return GetAsync<UserNoteModel>(parameters, cancellationToken);
        }

        public Task<PagedList<UserCurrentUsageModel>> CurrentUsageAsync(UserCurrentUsageFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["usage", "current"], filter);
            return GetAsync<PagedList<UserCurrentUsageModel>>(parameters, cancellationToken);
        }

        public Task<UsageModel?> CurrentUsageAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "usage", "current"]);
            return GetAsync<UsageModel?>(parameters, cancellationToken);
        }

        public Task<UserBalanceExtendedModel> BalanceAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "balance"]);
            return GetAsync<UserBalanceExtendedModel>(parameters, cancellationToken);
        }

        public Task<UserBalanceExtendedModel> BalanceAsync(int id, int hostGroupId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "hostgroup", hostGroupId, "balance"]);
            return GetAsync<UserBalanceExtendedModel>(parameters, cancellationToken);
        }

        public Task<UserLoginResultModel> LoginAsync(int id, int hostId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "login", hostId]);
            return GetAsync<UserLoginResultModel>(parameters, cancellationToken);
        }

        public Task<UserLogoutResultModel> LogoutAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "logout"]);
            return GetAsync<UserLogoutResultModel>(parameters, cancellationToken);
        }

        public Task<UserCountersModel> GetCountersAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["counters"]);
            return GetAsync<UserCountersModel>(parameters, cancellationToken);
        }

        public Task<UserModelPicture> GetUserPictureAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "picture"]);
            return GetAsync<UserModelPicture>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UpdateUserPictureAsync(int id, UserModelPicture model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "picture"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateUserBanAsync(int id, UserBanModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "ban"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateUserAddressAsync(int id, UserAddressModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "address"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> UpdateUserContactInformationAsync(int id, UserContactInformationModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "contactinformation"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }
    }
}
