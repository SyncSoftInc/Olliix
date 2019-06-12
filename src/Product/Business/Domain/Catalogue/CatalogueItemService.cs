using SyncSoft.Olliix.Product.Command.Catalogue;
using SyncSoft.Olliix.Product.Domain.Catalogue.GenerateItem;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Domain.Catalogue
{
    public class CatalogueItemService : ICatalogueItemService
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        //private static readonly Lazy<IProductItemMDAL> _lazyProductItemMDAL = ObjectContainer.LazyResolve<IProductItemMDAL>();
        //private IProductItemMDAL _ProductItemMDAL => _lazyProductItemMDAL.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  Create  -

        public async Task<string> GenerateByFamilyAsync(GenerateCatalogueItemCommand cmd)
        {
            var tran = new GenerateItemTransaction(cmd);
            await tran.RunAsync().ConfigureAwait(false);

            return tran.IsSuccess ? MsgCodes.SUCCESS : string.Join("\n", tran.ReadLogs());
        }

        #endregion
    }
}
