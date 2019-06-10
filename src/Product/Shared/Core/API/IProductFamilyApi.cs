using SyncSoft.App.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.API
{
    public interface IProductFamilyApi
    {
        Task<HttpResult<string>> CreateProductFamilyAsync(object cmd, CancellationToken? cancellationToken = null);
    }
}
