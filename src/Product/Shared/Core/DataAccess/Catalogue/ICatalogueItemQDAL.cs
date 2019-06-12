using SyncSoft.ECP.DTOs;
using SyncSoft.Olliix.Product.DTO.Catalogue;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.DataAccess.Catalogue
{
    public interface ICatalogueItemQDAL
    {
        Task<string> BulkInsertItemsAsync(IEnumerable<CatalogueItemDTO> items);
        Task<string> DeleteFamilyItemsAsync(string familyId);
        Task<PagedList<CatalogueItemDTO>> SearchAsync();
        Task<IList<CatalogueItemDTO>> GetFamilyItemsAsync(string familyId);
    }
}
