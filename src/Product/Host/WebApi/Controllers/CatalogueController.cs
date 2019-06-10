using Microsoft.AspNetCore.Mvc;
using SyncSoft.ECP.AspNetCore.Mvc.Controllers;
using SyncSoft.Olliix.Product.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.WebApi.Controllers
{
    public class CatalogueController : ApiController
    {
        [HttpGet("catalogues")]
        public async Task<IList<string>> GetCatalogueItemsAsync([FromQuery]SearchCatalogueQuery query)
        {
            return new string[] { "value1", "value2" };
        }
    }
}
