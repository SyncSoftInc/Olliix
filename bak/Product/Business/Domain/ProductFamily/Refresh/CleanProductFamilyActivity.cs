using SyncSoft.App.Components;
using SyncSoft.App.Transactions;
using SyncSoft.Olliix.Product.DataAccess.ProductFamily;
using SyncSoft.Olliix.Product.DTO.ProductFamily;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Domain.ProductFamily.Refresh
{
    public class CleanProductFamilyActivity : TccActivity
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IProductFamilyQDAL> _lazyProductFamilyQDAL = ObjectContainer.LazyResolve<IProductFamilyQDAL>();
        private IProductFamilyQDAL ProductFamilyQDAL => _lazyProductFamilyQDAL.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  Field(s)  -

        private const string Context_BackupFamily = "BackupFamily";

        #endregion
        // *******************************************************************************************************************************
        #region -  Property(ies)  -

        public override int RunOrdinal => 0;

        #endregion
        // *******************************************************************************************************************************
        #region -  Run  -

        protected override async Task RunAsync(CancellationToken? cancellationToken)
        {
            var familyId = Context.Get<string>("FamilyID");

            // 备份老数据
            var family = await ProductFamilyQDAL.GetFamilyAsync(familyId).ConfigureAwait(false);
            Context.Set(Context_BackupFamily, family);

            // 删除
            var msgCode = await ProductFamilyQDAL.DeleteFamilyAsync(familyId).ConfigureAwait(false);
            if (!msgCode.IsSuccess()) throw new Exception(msgCode);
            // ^^^^^^^^^^
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Rollback  -

        protected override async Task RollbackAsync()
        {
            var backupFamily = Context.Get<ProductFamilyDTO>(Context_BackupFamily);
            if (backupFamily.IsNotNull())
            {// 还原老数据
                var msgCode = await ProductFamilyQDAL.SaveFamilyAsync(backupFamily).ConfigureAwait(false);
                if (!msgCode.IsSuccess()) throw new Exception(msgCode);
                // ^^^^^^^^^^
            }
        }

        #endregion

    }
}
