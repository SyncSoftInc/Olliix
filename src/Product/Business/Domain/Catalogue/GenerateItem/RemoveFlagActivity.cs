using SyncSoft.App.Components;
using SyncSoft.App.Transactions;
using SyncSoft.Olliix.Product.DataAccess.ProductFamily;
using SyncSoft.Olliix.Product.DTO.ProductFamily;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Domain.Catalogue.GenerateItem
{
    public class RemoveFlagActivity : TccActivity
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IProductFamilyMDAL> _lazyProductFamilyMDAL = ObjectContainer.LazyResolve<IProductFamilyMDAL>();
        private IProductFamilyMDAL ProductFamilyMDAL => _lazyProductFamilyMDAL.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  Field(s)  -

        private const string Context_BackupFamily = "BackupFamily";

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

            // 备份老数据
            var dto = await ProductFamilyMDAL.GetFamilyAsync(familyId).ConfigureAwait(false);
            Context.Set(Context_BackupFamily, dto);

            // Remove Flag
            var msgCode = await ProductFamilyMDAL.RemoveFlagAsync(familyId, 1).ConfigureAwait(false);
            if (!msgCode.IsSuccess()) throw new Exception(msgCode);
            // ^^^^^^^^^^
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Rollback  -

        protected override async Task RollbackAsync()
        {
            var dto = Context.Get<ProductFamilyDTO>(Context_BackupFamily);
            if (dto.IsNotNull())
            {// 还原老数据
                var msgCode = await ProductFamilyMDAL.UpdateAsync(dto).ConfigureAwait(false);
                if (!msgCode.IsSuccess()) throw new Exception(msgCode);
                // ^^^^^^^^^^
            }
        }

        #endregion

    }
}
