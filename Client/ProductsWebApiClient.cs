using Gizmo.Web.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    [WebApiRoute("api/v2/products")]                                                                            
    public class ProductsWebApiClient : WebApiClientBase
    {
        #region CONSTRUCTOR

        public ProductsWebApiClient(HttpClient client) : base(client)
        {

        }

        #endregion

        #region Products

        public Task<PagedList<Product>> GetAsync(CancellationToken ct =default)
        {
            return GetAsync(default, ct);
        }

        public Task<PagedList<Product>> GetAsync(ProductGroupsFilter filter, CancellationToken ct = default)
        {
            return GetAsync<PagedList<Product>>(filter, ct);
        }

        public Task<CreateResult> CreateAsync(ProductModelCreate product,CancellationToken ct=default)
        {            
            return PostAsync<CreateResult>(CreateRequestUrl(), product, ct);
        }

        public Task<UpdateResult> UpdateAsync(ProductModelUpdate product, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrl(), product, ct);
        }

        public Task<Product> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<Product>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}"), ct);
        }

        #endregion

        #region Bundles
        public Task<IEnumerable<BundledProduct>> GetBundledProductsAsync(int bundleId, CancellationToken ct = default)
        {            
            return GetAsync<IEnumerable<BundledProduct>>(CreateRequestUrlWithRouteParameters($"bundle/{bundleId}/bundledproducts"), ct);
        }

        public Task<CreateResult> CreateBundledProductsAsync(int bundleId, BundledProductModelCreate bundledProduct, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"bundle/{bundleId}/bundledproducts"), bundledProduct, ct);
           
        }

        public Task<UpdateResult> UpdateBundledProduct(BundledProductModelUpdate bundledProduct, CancellationToken ct=default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"bundle/bundledproducts"), bundledProduct, ct);
            
        }

        public Task<DeleteResult> DeleteBundledProduct(int bundleId, int bundledProductId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"bundle/{bundleId}/bundledproducts/{bundledProductId}"), ct);
        }

        #endregion

        #region User Price

        public Task<IEnumerable<ProductUserPrice>> GetProductUserPricesAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<ProductUserPrice>>(CreateRequestUrlWithRouteParameters($"{id}/userprices"),ct);
        }
        public Task<CreateResult> CreateProductUserPrice(int id, ProductUserPriceModelCreate productUserPrice, CancellationToken ct = default)
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

        public Task<ProductPurchaseAvailability> GetPurchaseAvailabilityAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<ProductPurchaseAvailability>(CreateRequestUrlWithRouteParameters($"{id}/purchaseavailability"), ct);
        }

        public Task<UpdateResult> UpdatePurchaseAvailabilityAsync(int id, ProductPurchaseAvailabilityModelUpdate purchaseAvailability, CancellationToken ct = default)
        {            
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"{id}/purchaseavailability"), purchaseAvailability, ct);
        }

        #endregion

        #region Disallowed User Groups 

        public Task<IEnumerable<ProductDisallowedUserGroup>> GetDisallowedUserGroupsAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<ProductDisallowedUserGroup>>(CreateRequestUrlWithRouteParameters($"{id}/disallowedusergroups"), ct);
        }

        public Task<CreateResult> CreateDisallowedUserGroupAsync(int id, ProductDisallowedUserGroupModelCreate productDisallowedUserGroup, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"{id}/disallowedusergroups"),productDisallowedUserGroup, ct);
        }

        public Task<UpdateResult> UpdateDisallowUserGroupAsync(ProductDisallowedUserGroupModelUpdate productDisallowedUserGroup, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"disallowedusergroups"), productDisallowedUserGroup, ct);
        }

        public Task<DeleteResult> DeleteDisallowedUserGroupAsync(int id, int disallowedUserGroupId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}/disallowedusergroups/{disallowedUserGroupId}"), ct);
        }
        #endregion

        #region Bundle User Prices

        public Task<IEnumerable<ProductBundleUserPrice>> GetBundleUserPricesAsync(int id, int bundledProductId, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<ProductBundleUserPrice>>(CreateRequestUrlWithRouteParameters($"bundle/{id}/bundledproducts/{bundledProductId}/userprices"), ct);
        }

        public Task<CreateResult> CreateBundleUserPriceAsync(int id, int bunledProductId, ProductBundleUserPriceModelCreate productBundleUserPrice, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"bundle/{id}/bundledproducts/{bunledProductId}/userprices"), productBundleUserPrice, ct);
        }

        public Task<UpdateResult> UpdateBundleUserPriceAsync(ProductBundleUserPriceModelUpdate productBundleUserPrice, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters("bundle/bundledproducts/userprices"), productBundleUserPrice, ct);
        }

        public Task<DeleteResult> DeleteBundleUserPriceAsync(int id, int bundledProductId, int userPriceId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"bundle/{id}/bundledproducts/{bundledProductId}/userprices/{userPriceId}"), ct);
        }


        #endregion

        #region Usage Availability

        public Task<TimeProductUsageAvailability> GetUsageAvailabilityAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<TimeProductUsageAvailability>(CreateRequestUrlWithRouteParameters($"time/{id}/usageavailability"), ct);
        }

        public Task<UpdateResult> UpdateUsageAvailability(int id, TimeProductUsageAvailabilityModelUpdate usageAvailability, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"time/{id}/usageavailability"), usageAvailability, ct);
        }



        #endregion

        #region Disallowed Host Groups

        public Task<IEnumerable<TimeProductDisallowedHostGroup>> GetDisallowedHostGroupsAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<TimeProductDisallowedHostGroup>>(CreateRequestUrlWithRouteParameters($"time/{id}/disallowedhostgroups"), ct);
        }

        public Task<CreateResult> CreateDisallowedHostGroupAsync(int id, TimeProductDisallowedHostGroupModelCreate timeProductDisallowedHostGroup, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"time/{id}/disallowedhostgroups"), timeProductDisallowedHostGroup, ct);
        }

        public Task<UpdateResult> UpdateDisallowedHostGroupAsync(TimeProductDisallowedHostGroupModelUpdate timeProductDisallowedHostGroup, CancellationToken ct = default)
        {
            return PutAsync<UpdateResult>(CreateRequestUrlWithRouteParameters($"time/disallowedhostgroups"), timeProductDisallowedHostGroup, ct);
        }

        public Task<DeleteResult> DeleteDisallowedHostGroup(int id, int timeProductDisallowedHostGroup, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"time/{id}/disallowedhostgroups/{timeProductDisallowedHostGroup}"));
        }

        #endregion

        #region Images

        public Task<IEnumerable<ProductImage>> GetProductImagesAsync(int id, CancellationToken ct = default)
        {
            return GetAsync<IEnumerable<ProductImage>>(CreateRequestUrlWithRouteParameters($"{id}/images"), ct);
        }

        public Task<CreateResult> CreateProductImageAsync(int id, ProductImageModelCreate productImage, CancellationToken ct = default)
        {
            return PostAsync<CreateResult>(CreateRequestUrlWithRouteParameters($"{id}/images"), productImage, ct);
        }

        public Task<DeleteResult> DeleteProductImageAsync(int id, int productImageId, CancellationToken ct = default)
        {
            return DeleteAsync<DeleteResult>(CreateRequestUrlWithRouteParameters($"{id}/images/{productImageId}"), ct);
        }

        #endregion
    }
}
