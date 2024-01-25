using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Gizmo.Web.Api.Models.Abstractions;
using Gizmo.Web.Api.Models;
using System.Threading.Tasks;
using System.Threading;

namespace Gizmo.Web.Api.Client
{
    public static class AsyncEnumeration
    {
        /// <summary>
        /// Async enumeration.
        /// </summary>
        /// <typeparam name="TFilter">Model filter type.</typeparam>
        /// <typeparam name="TModel">Model type.</typeparam>
        /// <param name="filter">Model filter.</param>
        /// <param name="func">Filter function.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Async enumerable.</returns>
        public static async IAsyncEnumerable<TModel> AsyncEnumerate<TFilter, TModel>(TFilter filter,
            Func<TFilter, CancellationToken, Task<PagedList<TModel>>> func,
            [EnumeratorCancellation()] CancellationToken cancellationToken)
            where TFilter : class, IModelFilter<TModel> where TModel : class, IWebApiModel
        {
            ModelFilterPagination pagination = filter.Pagination;
            while (!cancellationToken.IsCancellationRequested)
            {
                filter.Pagination = pagination;
                var pagedResult = await func(filter, cancellationToken);
                foreach (var item in pagedResult.Data)
                {
                    yield return item;
                }

                if (pagedResult.NextCursor == null)
                    yield break;

                pagedResult.SetCursor(pagination);
            }
        }
    }
}
