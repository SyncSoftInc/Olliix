using SyncSoft.App.Components;
using SyncSoft.App.Transactions;
using SyncSoft.Olliix.Product.DataAccess.Catalogue;
using SyncSoft.Olliix.Product.DTO.Catalogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Domain.Catalogue
{
    public class CleanFamilyActivity : TccActivity
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<ICatalogueItemQDAL> _lazyCatalogueItemQDAL = ObjectContainer.LazyResolve<ICatalogueItemQDAL>();
        private ICatalogueItemQDAL _CatalogueItemQDAL => _lazyCatalogueItemQDAL.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  Field(s)  -

        private const string Context_BackupItems = "BackupItems";

        #endregion
        // *******************************************************************************************************************************
        #region -  Run  -

        protected override async Task RunAsync(CancellationToken? cancellationToken)
        {
            var familyId = Context.Get<string>("FamilyID");

            // 备份老数据
            var items = await _CatalogueItemQDAL.GetFamilyItemsAsync(familyId).ConfigureAwait(false);
            Context.Set(Context_BackupItems, items);

            // 删除
            var msgCode = await _CatalogueItemQDAL.DeleteFamilyItemsAsync(familyId).ConfigureAwait(false);
            if (!msgCode.IsSuccess()) throw new Exception(msgCode);
            // ^^^^^^^^^^
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
