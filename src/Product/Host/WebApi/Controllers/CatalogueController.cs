using Microsoft.AspNetCore.Mvc;
using SyncSoft.ECP.AspNetCore.Mvc.Controllers;
using SyncSoft.Olliix.Product.Command.Catalogue;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.WebApi.Controllers
{
    public class CatalogueController : ApiController
    {
        [HttpPost("catalogue/items")]
        public async Task<string> GenerateFamilyItems(GenerateCatalogueItemCommand cmd)
        {
            return await RequestAsync(cmd).ConfigureAwait(false);
        }
    }
}
