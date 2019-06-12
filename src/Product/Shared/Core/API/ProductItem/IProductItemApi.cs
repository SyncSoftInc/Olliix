using SyncSoft.App.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.API.ProductItem
{
    public interface IProductItemApi
    {
        Task<HttpResult<string>> CreateProductItemAsync(object cmd, CancellationToken? cancellationToken = null);
    }
}
