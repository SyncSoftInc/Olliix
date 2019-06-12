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
        private IProductItemMDAL _ProductItemMDAL => _lazyProductItemMDAL.Value;

        private static readonly Lazy<ICatalogueItemQDAL> _lazyCatalogueItemQDAL = ObjectContainer.LazyResolve<ICatalogueItemQDAL>();
        private ICatalogueItemQDAL _CatalogueItemQDAL => _lazyCatalogueItemQDAL.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  Field(s)  -

        private const string Context_BackupItems = "BackupItems";

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

            var family = await _ProductItemMDAL.GetFamilyWithItemsAsync(familyId).ConfigureAwait(false);
            if (family.IsNotNull() && family.Items.IsPresent())
            {
                var catalogueItems = family.Items
                    .GroupBy(x => new { x.Family_ID, x.ImageHash })
                    .SelectMany(x =>
                    {
                        var productItem = x.First();
                        var catalogueItem = new CatalogueItemDTO();

                        catalogueItem.Name = productItem.Name;
                        catalogueItem.Family_ID = productItem.Family_ID;
                        catalogueItem.ImageHash = productItem.ImageHash;
                        catalogueItem.ImageUrl = productItem.ImageUrl;
                        //catalogueItem.DetailUrl = productItem.DetailUrl;
                        //catalogueItem.BrandUrl = productItem.BrandUrl;
                        catalogueItem.Brand = productItem.Brand;
                        catalogueItem.Room = productItem.Room;
                        catalogueItem.Size = productItem.Size;
                        catalogueItem.Color = productItem.Color;
                        catalogueItem.Price = productItem.Price;

                        catalogueItem.Search_ItemNOs = string.Join(",", x.Select(a => a.ItemNo));
                        //catalogueItem.Search_Colors = string.Join(",", x.Select(a => a.Color));

                        return new[] { catalogueItem };
                    });

                var msgCode = await _CatalogueItemQDAL.BulkInsertItemsAsync(catalogueItems).ConfigureAwait(false);
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
