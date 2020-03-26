using SyncSoft.App.Components;
using SyncSoft.Olliix.Product.Command.ProductItem;
using SyncSoft.Olliix.Product.DataAccess.ProductItem;
using System;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Domain.ProductItem
{
    public class ProductItemService : IProductItemService
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IProductItemMDAL> _lazyProductItemMDAL = ObjectContainer.LazyResolve<IProductItemMDAL>();
        private IProductItemMDAL ProductItemMDAL => _lazyProductItemMDAL.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  Create  -

        public async Task<string> CreateProductItemAsync(CreateProductItemCommand cmd)
        {
            return await ProductItemMDAL.InsertAsync(cmd).ConfigureAwait(false);
        }

        #endregion
    }
}
