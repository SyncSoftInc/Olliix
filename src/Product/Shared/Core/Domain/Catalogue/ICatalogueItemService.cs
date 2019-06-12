using SyncSoft.Olliix.Product.Command.Catalogue;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Domain.Catalogue
{
    public interface ICatalogueItemService
    {
        Task<string> GenerateByFamilyAsync(GenerateCatalogueItemCommand cmd);
    }
}
