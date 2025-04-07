using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Gizmo.Web.Api.Models;

namespace Gizmo.Web.Api.Clients
{
    [WebApiRoute("api/v3/products")]
    public sealed class ProductsWebApiClient : WebApiClientBase
    {
        public ProductsWebApiClient(HttpClient httpClient, IOptions<WebApiClientOptions> options, IPayloadSerializerProvider payloadSerializerProvider) :
            base(httpClient, options, payloadSerializerProvider)
        {
        }

        public Task<PagedList<ProductModel>> GetAsync(ProductsFilter filter, CancellationToken ct = default)
        {
            var parameters = new UriParameters(filter);
            return GetAsync<PagedList<ProductModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateAsync(ProductModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateAsync(ProductModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters();
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<ProductModel> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return GetAsync<ProductModel>(parameters, ct);
        }

        public Task<DeleteResult> DeleteAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(id);
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<IEnumerable<ProductBundledModel>> GetBundledProductsAsync(int bundleId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "bundle", bundleId, "bundledproducts" });
            return GetAsync<IEnumerable<ProductBundledModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateBundledProductsAsync(int bundleId, ProductBundledModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "bundle", bundleId, "bundledproducts" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateBundledProductAsync(ProductBundledModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "bundle", "bundledproducts" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteBundledProductAsync(int bundleId, int bundledProductId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "bundle", bundleId, "bundledproducts", bundledProductId });
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<IEnumerable<ProductUserPriceModel>> GetProductUserPricesAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "userprices" });
            return GetAsync<IEnumerable<ProductUserPriceModel>>(parameters, ct);
        }
        
        public Task<CreateResult> CreateProductUserPriceAsync(int id, ProductUserPriceModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "userprices" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateProductUserPriceAsync(ProductUserPriceModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "userprices" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteProductUserPriceAsync(int id, int userPriceId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "userprices", userPriceId });
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<ProductPurchaseAvailabilityModel> GetPurchaseAvailabilityAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "purchaseavailability" });
            return GetAsync<ProductPurchaseAvailabilityModel>(parameters, ct);
        }

        public Task<UpdateResult> UpdatePurchaseAvailabilityAsync(int id, ProductPurchaseAvailabilityModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "purchaseavailability" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<IEnumerable<ProductDisallowedUserGroupModel>> GetDisallowedUserGroupsAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "disallowedusergroups" });
            return GetAsync<IEnumerable<ProductDisallowedUserGroupModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateDisallowedUserGroupAsync(int id, ProductDisallowedUserGroupModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "disallowedusergroups" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateDisallowedUserGroupAsync(ProductDisallowedUserGroupModelUpdate models, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "disallowedusergroups" });
            return PutAsync<UpdateResult>(parameters, models, ct);
        }

        public Task<DeleteResult> DeleteDisallowedUserGroupAsync(int id, int disallowedUserGroupId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "disallowedusergroups", disallowedUserGroupId });
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<IEnumerable<ProductBundledUserPriceModel>> GetBundleProductUserPricesAsync(int id, int bundledProductId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "bundle", id, "bundledproducts", bundledProductId, "userprices" });
            return GetAsync<IEnumerable<ProductBundledUserPriceModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateBundleProductUserPriceAsync(int id, int bundledProductId, ProductBundledUserPriceModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "bundle", id, "bundledproducts", bundledProductId, "userprices" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateBundleProductUserPriceAsync(ProductBundledUserPriceModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "bundle", "bundledproducts", "userprices" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteBundleProductUserPriceAsync(int id, int bundledProductId, int userPriceId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "bundle", id, "bundledproducts", bundledProductId, "userprices", userPriceId });
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<ProductTimeUsageAvailabilityModel> GetUsageAvailabilityAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "time", id, "usageavailability" });
            return GetAsync<ProductTimeUsageAvailabilityModel>(parameters, ct);
        }

        public Task<UpdateResult> UpdateUsageAvailabilityAsync(int id, ProductTimeUsageAvailabilityModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "time", id, "usageavailability" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<IEnumerable<ProductTimeDisallowedHostGroupModel>> GetDisallowedHostGroupsAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "time", id, "disallowedhostgroups" });
            return GetAsync<IEnumerable<ProductTimeDisallowedHostGroupModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateDisallowedHostGroupAsync(int id, ProductTimeDisallowedHostGroupModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "time", id, "disallowedhostgroups" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateDisallowedHostGroupAsync(ProductTimeDisallowedHostGroupModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "time", "disallowedhostgroups" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteDisallowedHostGroupAsync(int id, int timeProductDisallowedHostGroup, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "time", id, "disallowedhostgroups", timeProductDisallowedHostGroup });
            return DeleteAsync<DeleteResult>(parameters);
        }

        public Task<IEnumerable<ProductImageModel>> GetProductImagesAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "images" });
            return GetAsync<IEnumerable<ProductImageModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateProductImageAsync(int id, ProductImageModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "images" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateProductImageAsync(ProductImageModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "images" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteProductImageAsync(int id, int productImageId, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "images", productImageId });
            return DeleteAsync<DeleteResult>(parameters, ct);
        }

        public Task<IEnumerable<BranchReferenceModel>> BranchesGetAsync(int id, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "branches"]);
            return GetAsync<IEnumerable<BranchReferenceModel>>(parameters, cancellationToken);
        }

        public Task<UpdateResult> BranchSetAsync(int id, IEnumerable<BranchReferenceModelUpdate> entries, CancellationToken cancellationToken = default)
        {
            var parameters = new UriParameters([id, "branches"]);
            return PostAsync<UpdateResult>(parameters, entries, cancellationToken);
        }

        public Task<IEnumerable<ProductHiddenHostGroupModel>> GetHiddenHostGroupsAsync(int id, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "hiddenhostgroups" });
            return GetAsync<IEnumerable<ProductHiddenHostGroupModel>>(parameters, ct);
        }

        public Task<CreateResult> CreateHiddenHostGroupAsync(int id, ProductHiddenHostGroupModelCreate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "hiddenhostgroups" });
            return PostAsync<CreateResult>(parameters, model, ct);
        }

        public Task<UpdateResult> UpdateHiddenHostGroupAsync(ProductHiddenHostGroupModelUpdate model, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { "hiddenhostgroups" });
            return PutAsync<UpdateResult>(parameters, model, ct);
        }

        public Task<DeleteResult> DeleteHiddenHostGroupAsync(int id, int productHiddenHostGroup, CancellationToken ct = default)
        {
            var parameters = new UriParameters(new object[] { id, "hiddenhostgroups", productHiddenHostGroup });
            return DeleteAsync<DeleteResult>(parameters);
        }

    }
}
