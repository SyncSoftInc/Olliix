using SyncSoft.Olliix.Product.Command.ProductFamily;
using SyncSoft.Olliix.Product.Domain.ProductFamily.Refresh;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Domain.ProductFamily
{
    public class ProductFamilyService : IProductFamilyService
    {
        public async Task<string> RefreshProductFamilyAsync(RefreshProductFamilyCommand cmd)
        {
            var tran = new RefreshTransaction(cmd);
            await tran.RunAsync().ConfigureAwait(false);
            return tran.IsSuccess ? MsgCodes.SUCCESS : string.Join("\n", tran.ReadLogs());
        }
    }
}
