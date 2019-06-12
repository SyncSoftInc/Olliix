using SyncSoft.App.Components;
using SyncSoft.App.Transactions;
using SyncSoft.Olliix.Product.DataAccess.Catalogue;
using SyncSoft.Olliix.Product.DataAccess.ProductItem;
using SyncSoft.Olliix.Product.DTO.Catalogue;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Domain.Catalogue
{
    public class GenerateItemsActivity : TccActivity
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IProductItemMDAL> _lazyProductItemMDAL = ObjectContainer.LazyResolve<IProductItemMDAL>();
        private IProductItemMDAL ProductItemMDAL => _lazyProductItemMDAL.Value;

        private static readonly Lazy<ICatalogueItemQDAL> _lazyCatalogueItemQDAL = ObjectContainer.LazyResolve<ICatalogueItemQDAL>();
        private ICatalogueItemQDAL CatalogueItemQDAL => _lazyCatalogueItemQDAL.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  Property(ies)  -

        public override int RunOrdinal => 1;

        #endregion
        // *******************************************************************************************************************************
        #region -  Run  -

        protected override async Task RunAsync(CancellationToken? cancellationToken)
        {
            var familyId = Context.Get<string>("FamilyID");

            var family = await ProductItemMDAL.GetFamilyWithItemsAsync(familyId).ConfigureAwait(false);
            if (family.IsNotNull() && family.Items.IsPresent())
            {
                var catalogueItems = family.Items
                    .GroupBy(x => new { x.Family_ID, x.ImageHash })
                    .SelectMany(x =>
                    {
                        var productItem = x.First();
                        var catalogueItem = new CatalogueItemDTO
                        {
                            Name = productItem.Name,
                            Family_ID = productItem.Family_ID,
                            ImageHash = productItem.ImageHash,
                            ImageUrl = productItem.ImageUrl,
                            //catalogueItem.DetailUrl = productItem.DetailUrl;
                            //catalogueItem.BrandUrl = productItem.BrandUrl;
                            Brand = productItem.Brand,
                            Room = productItem.Room,
                            Size = productItem.Size,
                            Color = productItem.Color,
                            Price = productItem.Price,

                            Search_ItemNOs = string.Join(",", x.Select(a => a.ItemNo))
                        };
                        //catalogueItem.Search_Colors = string.Join(",", x.Select(a => a.Color));

                        return new[] { catalogueItem };
                    });

                var msgCode = await CatalogueItemQDAL.BulkInsertItemsAsync(catalogueItems).ConfigureAwait(false);
                if (!msgCode.IsSuccess()) throw new Exception(msgCode);
                // ^^^^^^^^^^
            }

            throw new Exception($"Cannot find family '{familyId}'");
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Rollback  -

        protected override Task RollbackAsync() => Task.CompletedTask;  // 最后一步不需要回滚

        #endregion

    }
}
