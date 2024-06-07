﻿using Gizmo.Web.Api.Models;

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
            base(httpClient,options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<UserModel>> GetAsync(UsersFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<UserModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(UserModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(UserModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<UserModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<UserModel>(parameters, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<IEnumerable<UserAttributeModel>> GetUserAttributeAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "attributes" });
            return GetAsync<IEnumerable<UserAttributeModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateUserAttributeAsync(int id, UserAttributeModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "attributes" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateUserAttributeAsync(UserAttributeModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "attributes" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteUserAttributeAsync(int id, int userAttributeId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "attributes", userAttributeId });
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<UserNoteCountModel> GetUserNotesCountAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "notes", "count"]);
            return GetAsync<UserNoteCountModel>(parameters, ct);
        }

        public Task<PagedList<UserNoteModel>> GetUserNotesAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "notes" });
            return GetAsync<PagedList<UserNoteModel>>(parameters, ct);
        }

        public Task<PagedList<UserNoteModel>> GetUserNotesAsync(int id, UserNotesFilter model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "notes" });
            return GetAsync<PagedList<UserNoteModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateUserNoteAsync(int id, UserNoteModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "notes" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateUserNoteAsync(UserNoteModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "notes" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteUserNoteAsync(int id, int noteId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "notes", noteId});
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<UserNoteModel> GetUserNoteByIdAsync(int id, int userNoteId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "notes", userNoteId });
            return GetAsync<UserNoteModel>(parameters, ct);
        }

        public Task<PagedList<UserCurrentUsageModel>> CurrentUsageAsync(UserCurrentUsageFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(["usage", "current"], filter);
            return GetAsync<PagedList<UserCurrentUsageModel>>(parameters, ct);
        }

        public Task<UsageModel?> CurrentUsageAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "usage", "current"]);
            return GetAsync<UsageModel?>(parameters, ct);
        }

        public Task<UserBalanceExtendedModel> BalanceAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "balance"]);
            return GetAsync<UserBalanceExtendedModel>(parameters, ct);
        }

        public Task<UserBalanceExtendedModel> BalanceAsync(int id, int hostGroupId, CancellationToken ct = default)
        {
            var parameters = new UriParameters([id, "hostgroup", hostGroupId, "balance"]);
            return GetAsync<UserBalanceExtendedModel>(parameters, ct);
        }
    }
}
