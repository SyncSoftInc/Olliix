using SyncSoft.Olliix.Product.Command.ProductFamily;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Domain.ProductFamily
{
    public interface IProductFamilyService
    {
        Task<string> RefreshProductFamilyAsync(RefreshProductFamilyCommand cmd);
    }
}