using SyncSoft.App.Components;
using SyncSoft.App.Transactions;
using SyncSoft.Olliix.Product.DataAccess;
using SyncSoft.Olliix.Product.DTO;
using System;
using System.Collections.Generic;
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

            var items = await _ProductItemMDAL.GetFamilyWithItemsAsync(familyId).ConfigureAwait(false);
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Rollback  -

        protected override async Task RollbackAsync()
        {
            var backupItems = Context.Get<IList<CatalogueItemDTO>>(Context_BackupItems);
            if (backupItems.IsPresent())
            {// 还原老数据
                var msgCode = await _CatalogueItemQDAL.BulkInsertItemsAsync(backupItems).ConfigureAwait(false);
                if (!msgCode.IsSuccess()) throw new Exception(msgCode);
                // ^^^^^^^^^^
            }
        }

        #endregion

    }
}
