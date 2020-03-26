using SyncSoft.Olliix.Product.DTO.ProductFamily;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.DataAccess.ProductFamily
{
    public interface IProductFamilyMDAL
    {
        //Task<ProductFamilyDTO> GetFamilyAsync(string familyId);
        Task<ProductFamilyDTO> GetFamilyWithItemsAsync(string familyId);
        Task<string> InsertAsync(ProductFamilyDTO dto);
        //Task<string> UpdateAsync(ProductFamilyDTO dto);
        Task<string> RemoveFlagsAsync(string familyId, int flags);
        Task<string> AddFlagsAsync(string familyId, int flags);
    }
}
