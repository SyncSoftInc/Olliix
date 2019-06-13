using SyncSoft.Olliix.Product.Command.ProductFamily;
using SyncSoft.Olliix.Product.DTO.ProductFamily;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.DataAccess.ProductFamily
{
    public interface IProductFamilyMDAL
    {
        Task<ProductFamilyDTO> GetFamilyAsync(string id);
        Task<ProductFamilyDTO> GetFamilyWithItemsAsync(string familyId);
        Task<string> InsertAsync(CreateProductFamilyCommand cmd);
        Task<string> UpdateAsync(ProductFamilyDTO dto);
        Task<string> RemoveFlagAsync(string id, int flag);
    }
}
