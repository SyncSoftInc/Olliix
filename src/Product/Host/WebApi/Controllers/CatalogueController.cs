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
        public Task<IList<string>> GenerateFamilyItems(GenerateCatalogueItemCommand cmd)
        {
            if (cmd == null)
            {
                throw new System.ArgumentNullException(nameof(cmd));
            }

            throw new System.NotImplementedException();
        }
    }
}
