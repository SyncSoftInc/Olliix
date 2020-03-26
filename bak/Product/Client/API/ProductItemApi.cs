using SyncSoft.App.Http;
using SyncSoft.App.WebApi.Auth;
using SyncSoft.Olliix.API;
using SyncSoft.Olliix.Product.API.ProductItem;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.API
{
    public class ProductItemApi : OlliixApiBase, IProductItemApi
    {
        public Task<HttpResult<string>> CreateProductItemAsync(object cmd, CancellationToken? cancellationToken)
        {
            return base.PostAsync<string>(BearerAuthModeEnum.Client, "product/item", cmd, cancellationToken: cancellationToken);
        }
    }
}
