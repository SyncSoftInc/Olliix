using SyncSoft.App.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.API.ProductFamily
{
    public interface IProductFamilyApi
    {
        Task<HttpResult<string>> CreateProductFamilyAsync(object cmd, CancellationToken? cancellationToken = null);
        Task<HttpResult<string>> RefreshAsync(string familyId, CancellationToken? cancellationToken = null);
    }
}
