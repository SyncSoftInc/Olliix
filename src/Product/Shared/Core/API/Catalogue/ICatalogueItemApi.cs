using SyncSoft.App.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.API.Catalogue
{
    public interface ICatalogueItemApi
    {
        Task<HttpResult<IList<string>>> GenerateFamilyItemsAsync(object cmd, CancellationToken? cancellationToken = null);
    }
}
