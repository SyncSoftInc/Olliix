using System.Threading.Tasks;
using SyncSoft.Olliix.Product.DTO;

namespace SyncSoft.Olliix.Product.DataFacade
{
    public interface IProductItemDF
    {
        Task<ProductFamilyDTO> GetProductFamilyAsync(string famliyId);
    }
}
