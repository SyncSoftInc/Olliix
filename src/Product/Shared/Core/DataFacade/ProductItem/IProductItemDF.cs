using SyncSoft.Olliix.Product.DTO.ProductFamily;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.DataFacade.ProductItem
{
    public interface IProductItemDF
    {
        Task<ProductFamilyDTO> GetProductFamilyAsync(string familyId);
    }
}
