using Gizmo.Web.Api.Models;

using Microsoft.Extensions.Options;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v2/products")]
    public class ProductsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR

        public ProductsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        #endregion

        #region FUNCTIONS

        #region Products

        public Task<PagedList<ProductModel>> GetAsync(ProductsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<ProductModel>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ProductModelCreate product, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrl(), product, ct);
        }

        public Task<UpdateResult> UpdateAsync(ProductModelUpdate product, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), product, ct);
        }

        public Task<ProductModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ProductModel>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion

        #region Bundles
        public Task<IEnumerable<ProductBundledModel>> GetBundledProductsAsync(int bundleId, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<ProductBundledModel>>(CreateRequestUrlWithRouteParameters($"bundle/{bundleId}/bundledproducts"), ct);
        }

        public Task<CreateResult> CreateBundledProductsAsync(int bundleId, ProductBundledModelCreate bundledProduct, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"bundle/{bundleId}/bundledproducts"), bundledProduct, ct);

        }

        public Task<UpdateResult> UpdateBundledProductAsync(ProductBundledModelUpdate bundledProduct, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"bundle/bundledproducts"), bundledProduct, ct);

        }

        public Task<DeleteResult> DeleteBundledProductAsync(int bundleId, int bundledProductId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"bundle/{bundleId}/bundledproducts/{bundledProductId}"), ct);
        }

        #endregion

        #region User Price

        public Task<IEnumerable<ProductUserPriceModel>> GetProductUserPricesAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<ProductUserPriceModel>>(CreateRequestUrlWithRouteParameters($"{id}/userprices"), ct);
        }
        public Task<CreateResult> CreateProductUserPriceAsync(int id, ProductUserPriceModelCreate productUserPrice, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"{id}/userprices"), productUserPrice, ct);
        }

        public Task<UpdateResult> UpdateProductUserPriceAsync(ProductUserPriceModelUpdate productUserPrice, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"userprices"), productUserPrice, ct);
        }

        public Task<DeleteResult> DeleteProductUserPriceAsync(int id, int userPriceId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}/userprices/{userPriceId}"));
        }

        #endregion

        #region Purchase Availability

        public Task<ProductPurchaseAvailabilityModel> GetPurchaseAvailabilityAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ProductPurchaseAvailabilityModel>(CreateRequestUrlWithRouteParameters($"{id}/purchaseavailability"), ct);
        }

        public Task<UpdateResult> UpdatePurchaseAvailabilityAsync(int id, ProductPurchaseAvailabilityModelUpdate purchaseAvailability, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"{id}/purchaseavailability"), purchaseAvailability, ct);
        }

        #endregion

        #region Disallowed User Groups 

        public Task<IEnumerable<ProductDisallowedUserGroupModel>> GetDisallowedUserGroupsAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<ProductDisallowedUserGroupModel>>(CreateRequestUrlWithRouteParameters($"{id}/disallowedusergroups"), ct);
        }

        public Task<CreateResult> CreateDisallowedUserGroupAsync(int id, ProductDisallowedUserGroupModelCreate productDisallowedUserGroup, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"{id}/disallowedusergroups"), productDisallowedUserGroup, ct);
        }

        public Task<UpdateResult> UpdateDisallowedUserGroupAsync(ProductDisallowedUserGroupModelUpdate productDisallowedUserGroup, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"disallowedusergroups"), productDisallowedUserGroup, ct);
        }

        public Task<DeleteResult> DeleteDisallowedUserGroupAsync(int id, int disallowedUserGroupId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}/disallowedusergroups/{disallowedUserGroupId}"), ct);
        }
        #endregion

        #region Bundle User Prices

        public Task<IEnumerable<ProductBundledUserPriceModel>> GetBundleProductUserPricesAsync(int id, int bundledProductId, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<ProductBundledUserPriceModel>>(CreateRequestUrlWithRouteParameters($"bundle/{id}/bundledproducts/{bundledProductId}/userprices"), ct);
        }

        public Task<CreateResult> CreateBundleProductUserPriceAsync(int id, int bunledProductId, ProductBundledUserPriceModelCreate productBundleUserPrice, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"bundle/{id}/bundledproducts/{bunledProductId}/userprices"), productBundleUserPrice, ct);
        }

        public Task<UpdateResult> UpdateBundleProductUserPriceAsync(ProductBundledUserPriceModelUpdate productBundleUserPrice, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters("bundle/bundledproducts/userprices"), productBundleUserPrice, ct);
        }

        public Task<DeleteResult> DeleteBundleProductUserPriceAsync(int id, int bundledProductId, int userPriceId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"bundle/{id}/bundledproducts/{bundledProductId}/userprices/{userPriceId}"), ct);
        }


        #endregion

        #region Usage Availability

        public Task<ProductTimeUsageAvailabilityModel> GetUsageAvailabilityAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ProductTimeUsageAvailabilityModel>(CreateRequestUrlWithRouteParameters($"time/{id}/usageavailability"), ct);
        }

        public Task<UpdateResult> UpdateUsageAvailabilityAsync(int id, ProductTimeUsageAvailabilityModelUpdate usageAvailability, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"time/{id}/usageavailability"), usageAvailability, ct);
        }

        #endregion

        #region Disallowed Host Groups

        public Task<IEnumerable<ProductTimeDisallowedHostGroupModel>> GetDisallowedHostGroupsAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<ProductTimeDisallowedHostGroupModel>>(CreateRequestUrlWithRouteParameters($"time/{id}/disallowedhostgroups"), ct);
        }

        public Task<CreateResult> CreateDisallowedHostGroupAsync(int id, ProductTimeDisallowedHostGroupModelCreate timeProductDisallowedHostGroup, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"time/{id}/disallowedhostgroups"), timeProductDisallowedHostGroup, ct);
        }

        public Task<UpdateResult> UpdateDisallowedHostGroupAsync(ProductTimeDisallowedHostGroupModelUpdate timeProductDisallowedHostGroup, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"time/disallowedhostgroups"), timeProductDisallowedHostGroup, ct);
        }

        public Task<DeleteResult> DeleteDisallowedHostGroupAsync(int id, int timeProductDisallowedHostGroup, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"time/{id}/disallowedhostgroups/{timeProductDisallowedHostGroup}"));
        }

        #endregion

        #region Images

        public Task<IEnumerable<ProductImageModel>> GetProductImagesAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<ProductImageModel>>(CreateRequestUrlWithRouteParameters($"{id}/images"), ct);
        }

        public Task<CreateResult> CreateProductImageAsync(int id, ProductImageModelCreate productImage, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"{id}/images"), productImage, ct);
        }

        public Task<UpdateResult> UpdateProductImageAsync(ProductImageModelUpdate productImage, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"images"), productImage, ct);
        }

        public Task<DeleteResult> DeleteProductImageAsync(int id, int productImageId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}/images/{productImageId}"), ct);
        }

        #endregion 

        #endregion
    }
}