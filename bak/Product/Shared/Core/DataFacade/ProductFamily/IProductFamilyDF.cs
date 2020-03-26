using SyncSoft.Olliix.Product.DTO.ProductFamily;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.DataFacade.ProductFamily
{
    public interface IProductFamilyDF
    {
        Task<ProductFamilyDTO> GetProductFamilyAsync(string familyId);
    }
}
