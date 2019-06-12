using Microsoft.AspNetCore.Mvc;
using SyncSoft.ECP.AspNetCore.Mvc.Controllers;
using SyncSoft.Olliix.Product.Command.Catalogue;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.WebApi.Controllers
{
    public class CatalogueController : ApiController
    {
        [HttpPost("catalogues/items")]
        public async Task<IList<string>> GenerateFamilyItems(GenerateCatalogueItemCommand cmd)
        {
            return new string[] { "value1", "value2" };
        }
    }
}
