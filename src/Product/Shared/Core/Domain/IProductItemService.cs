using SyncSoft.Olliix.Product.Command.ProductItem;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Domain
{
    public interface IProductItemService
    {
        Task<string> CreateProductItemAsync(CreateProductItemCommand cmd);
    }
}
