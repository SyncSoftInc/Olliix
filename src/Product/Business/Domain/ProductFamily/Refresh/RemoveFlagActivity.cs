using SyncSoft.App.Components;
using SyncSoft.App.Transactions;
using SyncSoft.Olliix.Product.DataAccess.ProductFamily;
using SyncSoft.Olliix.Product.Enum;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Domain.ProductFamily.Refresh
{
    public class RemoveFlagActivity : TccActivity
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IProductFamilyMDAL> _lazyProductFamilyMDAL = ObjectContainer.LazyResolve<IProductFamilyMDAL>();
        private IProductFamilyMDAL ProductFamilyMDAL => _lazyProductFamilyMDAL.Value;

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

            // Remove HasChanges flag
            var msgCode = await ProductFamilyMDAL.RemoveFlagsAsync(familyId, (int)ProductFlagsEnum.HasChanges).ConfigureAwait(false);
            if (!msgCode.IsSuccess()) throw new Exception(msgCode);
            // ^^^^^^^^^^
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Rollback  -

        protected override async Task RollbackAsync()
        {
            var familyId = Context.Get<string>("FamilyID");

            // Add HasChanges flag back
            var msgCode = await ProductFamilyMDAL.AddFlagsAsync(familyId, (int)ProductFlagsEnum.HasChanges).ConfigureAwait(false);
            if (!msgCode.IsSuccess()) throw new Exception(msgCode);
            // ^^^^^^^^^^
        }

        #endregion

    }
}
