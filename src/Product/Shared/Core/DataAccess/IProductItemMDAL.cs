using SyncSoft.Olliix.Product.Command.ProductItem;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.DataAccess
{
    public interface IProductItemMDAL
    {
        Task<string> InsertAsync(CreateProductItemCommand cmd);
    }
}
