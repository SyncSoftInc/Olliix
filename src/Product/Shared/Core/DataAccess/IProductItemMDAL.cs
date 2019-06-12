using SyncSoft.Olliix.Product.Command.ProductItem;
using SyncSoft.Olliix.Product.DTO;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.DataAccess
{
    public interface IProductItemMDAL
    {
        Task<string> InsertAsync(CreateProductItemCommand cmd);
        Task<ProductFamilyDTO> GetFamilyWithItemsAsync(string familyId);
    }
}
