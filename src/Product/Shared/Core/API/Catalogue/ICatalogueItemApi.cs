using SyncSoft.App.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.API.Catalogue
{
    public interface ICatalogueItemApi
    {
        Task<HttpResult<string>> GenerateFamilyItemsAsync(object cmd, CancellationToken? cancellationToken = null);
    }
}
