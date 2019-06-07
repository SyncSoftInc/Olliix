using System.Threading.Tasks;
using SyncSoft.Olliix.Product.Command.ProductItem;

namespace SyncSoft.Olliix.Product.DataAccess
{
    public interface IProductItemMDAL
    {
        Task<string> InsertAsync(CreateProductItemCommand cmd);
    }
}
