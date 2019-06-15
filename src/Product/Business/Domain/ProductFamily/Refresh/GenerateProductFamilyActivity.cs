using SyncSoft.App.Components;
using SyncSoft.App.Transactions;
using SyncSoft.Olliix.Product.DataAccess.ProductFamily;
using SyncSoft.Olliix.Product.Enum;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Domain.ProductFamily.Refresh
{
    public class GenerateProductFamilyActivity : TccActivity
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IProductFamilyQDAL> _lazyProductFamilyQDAL = ObjectContainer.LazyResolve<IProductFamilyQDAL>();
        private IProductFamilyQDAL ProductFamilyQDAL => _lazyProductFamilyQDAL.Value;

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

            var family = await ProductFamilyMDAL.GetFamilyWithItemsAsync(familyId).ConfigureAwait(false);
            if (family.IsNotNull() && family.Items.IsPresent())
            {
                if (!family.Flags.HasAnyFlag(ProductFlagsEnum.Inactive))
                {
                    var msgCode = await ProductFamilyQDAL.SaveFamilyAsync(family).ConfigureAwait(false);
                    if (!msgCode.IsSuccess()) throw new Exception(msgCode);
                    // ^^^^^^^^^^
                }
            }
            else
            {
                throw new Exception($"Cannot find family '{familyId}'");
            }
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Rollback  -

        protected override async Task RollbackAsync()
        {
            var familyId = Context.Get<string>("FamilyID");
            if (familyId.IsNotNull())
            {// 还原老数据
                var msgCode = await ProductFamilyQDAL.DeleteFamilyAsync(familyId).ConfigureAwait(false);
                if (!msgCode.IsSuccess()) throw new Exception(msgCode);
                // ^^^^^^^^^^
            }
        }

        #endregion

    }
}
