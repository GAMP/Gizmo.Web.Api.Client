using Gizmo.Web.Api.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/users")]
    public class UsersWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR
        
        public UsersWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) : 
            base(httpClient,options, payloadSerializerProvider)
        {
        }

        #endregion

        #region FUNCTIONS
        
        #region USERS

        public Task<PagedList<User>> GetAsync(CancellationToken ct = default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<User>> GetAsync(UsersFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<User>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(UserModelCreate user, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), user, ct);
        }

        public Task<UpdateResult> UpdateAsync(UserModelUpdate user, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), user, ct);
        }

        public Task<User> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<User>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }
        
        #endregion

        #region USER ATTRIBUTE

        public Task<IEnumerable<UserAttribute>> GetUserAttributeAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<UserAttribute>>(CreateRequestUrlWithRouteParameters($"{id}/attributes"), ct);
        }

        public Task<CreateResult> CreateUserAttributeAsync(int id, UserAttributeModelCreate userAttributeModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"{id}/attributes"), userAttributeModelCreate, ct);
        }

        public Task<UpdateResult> UpdateUserAttributeAsync(UserAttributeModelUpdate userAttributeModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters("attributes"), userAttributeModelUpdate, ct);
        }

        public Task<DeleteResult> DeleteUserAttributeAsync(int id, int userAttributeId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}/attributes/{userAttributeId}"), ct);
        }

        #endregion

        #region USER NOTES

        public Task<PagedList<UserNote>> GetUserNotesAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<PagedList<UserNote>>(CreateRequestUrlWithRouteParameters($"{id}/notes"), ct);
        }

        public Task<CreateResult> CreateUserNoteAsync(int id, UserNoteModelCreate userNoteModelCreate, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"{id}/notes"), userNoteModelCreate, ct);
        }

        public Task<UpdateResult> UpdateUserNoteAsync(UserNoteModelUpdate userNoteModelUpdate, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"notes"), userNoteModelUpdate, ct);
        }

        public Task<DeleteResult> DeleteUserNoteAsync(int id, int noteId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}/notes/{noteId}"), ct);
        }

        public Task<UserNote> GetUserNoteByIdAsync(int id, int userNoteId, CancellationToken ct = default)
        {
            return GetAsync<UserNote>(CreateRequestUrlWithRouteParameters($"{id}/notes/{userNoteId}"), ct);
        }

        #endregion 

        #endregion
    }
}
