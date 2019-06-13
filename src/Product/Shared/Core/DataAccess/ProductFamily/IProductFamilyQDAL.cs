using SyncSoft.Olliix.Product.DTO.ProductFamily;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.DataAccess.ProductFamily
{
    public interface IProductFamilyQDAL
    {
        Task<ProductFamilyDTO> GetFamilyAsync(string familyId);
        Task<string> SaveFamilyAsync(ProductFamilyDTO dto);
        Task<string> DeleteFamilyAsync(string familyId);
    }
}
