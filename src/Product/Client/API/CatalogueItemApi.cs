using SyncSoft.App.Http;
using SyncSoft.App.WebApi.Auth;
using SyncSoft.Olliix.API;
using SyncSoft.Olliix.Product.API.Catalogue;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.API
{
    public class CatalogueItemApi : OlliixApiBase, ICatalogueItemApi
    {
        public Task<HttpResult<IList<string>>> GenerateFamilyItemsAsync(object cmd, CancellationToken? cancellationToken)
        {
            return base.PostAsync<IList<string>>(BearerAuthModeEnum.Client, "catalogue/items", cmd, cancellationToken: cancellationToken);
        }
    }
}
