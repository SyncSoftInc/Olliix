using SyncSoft.App.Http;
using SyncSoft.App.WebApi.Auth;
using SyncSoft.Olliix.API;
using SyncSoft.Olliix.Product.API.ProductFamily;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.API
{
    public class ProductFamilyApi : OlliixApiBase, IProductFamilyApi
    {
        public Task<HttpResult<string>> CreateProductFamilyAsync(object cmd, CancellationToken? cancellationToken)
        {
            return base.PostAsync<string>(BearerAuthModeEnum.Client, "product/family", cmd, cancellationToken: cancellationToken);
        }

        public Task<HttpResult<string>> RefreshAsync(string familyId, CancellationToken? cancellationToken)
        {
            return base.PutAsync<string>(BearerAuthModeEnum.Client, $"product/family/{familyId}", null, cancellationToken: cancellationToken);
        }
    }
}
