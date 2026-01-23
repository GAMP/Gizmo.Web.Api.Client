using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;

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

        public Task<PagedList<UserSearchResultModel>> SearchAsync(UserSearchFilter filter, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["search"], filter);
            return GetAsync<PagedList<UserSearchResultModel>>(parameters, cancellationToken);
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

        public Task<UpdateResult> UndeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "undelete"]);
            return PutAsync<UpdateResult>(parameters, cancellationToken);
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

        public Task<Dictionary<int, UserBalanceExtendedModel>> BalanceAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["balance"]);
            return GetAsync<Dictionary<int, UserBalanceExtendedModel>>(parameters, cancellationToken);
        }

        public Task<UserBalanceExtendedModel> BalanceAsync(int id, CancellationToken cancellationToken = default)
        {
            return BalanceAsync(id, true, cancellationToken);
        }

        public Task<UserBalanceExtendedModel> BalanceAsync(int id, bool preferCache = false, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "balance"], new Dictionary<string, string>()
            {
                { "PreferCache", preferCache.ToString() }
            });
            return GetAsync<UserBalanceExtendedModel>(parameters, cancellationToken);
        }

        public Task<UserBalanceExtendedModel> BalanceAsync(int id, int hostGroupId, bool preferCache = false, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "hostgroup", hostGroupId, "balance"], new Dictionary<string, string>()
            {
                { "PreferCache", preferCache.ToString() }
            });
            return GetAsync<UserBalanceExtendedModel>(parameters, cancellationToken);
        }

        public Task<UserLoginResultModel> LoginAsync(int id, int hostId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "login", hostId]);
            return PostAsync<UserLoginResultModel>(parameters, cancellationToken);
        }

        public Task<UserLoginResultModel> LoginAsync(int id, int hostId, int slot, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "login", hostId, "slot", slot]);
            return PostAsync<UserLoginResultModel>(parameters, cancellationToken);
        }

        public Task<UserLoginResultModel> MoveAsync(int id, UserMoveModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "move"]);
            return PostAsync<UserLoginResultModel>(parameters, model, cancellationToken);
        }

        public Task<UserLogoutResultModel> LogoutAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "logout"]);
            return PostAsync<UserLogoutResultModel>(parameters, cancellationToken);
        }

        public Task<UsersCountersModel> GetCountersAsync(CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["counters"]);
            return GetAsync<UsersCountersModel>(parameters, cancellationToken);
        }

        public Task<UserCountersModel> GetCountersAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "counters"]);
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

        public Task<UpdateResult> UpdateUserPersonalInformationAsync(int id, UserPersonalInformationModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "personalinformation"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> RequestPersonalInfoAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "requestpersonalinfo"]);
            return PutAsync<UpdateResult>(parameters, cancellationToken);
        }

        public Task<UpdateResult> ResetPasswordAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "resetpassword"]);
            return PutAsync<UpdateResult>(parameters, cancellationToken);
        }

        public Task<UpdateResult> UpdateUserGroupAsync(int id, UserUserGroupModelUpdate model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "usergroup"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> AssetCheckOutAsync(int userId, int assetId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([userId, "asset", assetId, "checkout"]);
            return PutAsync<UpdateResult>(parameters, cancellationToken);
        }

        public Task<UpdateResult> AssetCheckInAsync(int assetId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["asset", assetId, "checkin"]);
            return PutAsync<UpdateResult>(parameters, cancellationToken);
        }

        public Task<UserStatsModel> GetStatsAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "stats"]);
            return GetAsync<UserStatsModel>(parameters, cancellationToken);
        }

        public Task<IEnumerable<UserCommunicationChannel>> CommunicationChannelsAsync(int userId, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([userId, "communicationchannels"]);
            return GetAsync<IEnumerable<UserCommunicationChannel>>(parameters, cancellationToken);
        }

        public Task<UpdateResult> SetSmartCardAsync(int userId, UserSetSmartCardUidModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([userId, "smartcard"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<ExistResult> SmartCardExistAsync(string smartCardUid, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters(["smartcard", smartCardUid, "exist"]);
            return GetAsync<ExistResult>(parameters, cancellationToken);
        }

        public Task<UpdateResult> NegativeBalanceSetAsync(int id, UserNegativeBalanceSetModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "negativebalance"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }

        public Task<UpdateResult> BillingOptionsSetAsync(int id, UserBillingOptionsSetModel model, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "billingoptions"]);
            return PutAsync<UpdateResult>(parameters, model, cancellationToken);
        }
    }
}
