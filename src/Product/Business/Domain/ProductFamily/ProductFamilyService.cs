using SyncSoft.App;
using SyncSoft.App.Components;
using SyncSoft.Olliix.Product.Command.ProductFamily;
using SyncSoft.Olliix.Product.DataAccess.ProductFamily;
using SyncSoft.Olliix.Product.Domain.ProductFamily.Refresh;
using SyncSoft.Olliix.Product.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Domain.ProductFamily
{
    public class ProductFamilyService : IProductFamilyService
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IProductFamilyMDAL> _lazyProductFamilyMDAL = ObjectContainer.LazyResolve<IProductFamilyMDAL>();
        private IProductFamilyMDAL ProductFamilyMDAL => _lazyProductFamilyMDAL.Value;

        //private static readonly Lazy<ICatalogueItemQDAL> _lazyCatalogueItemQDAL = ObjectContainer.LazyResolve<ICatalogueItemQDAL>();
        //private ICatalogueItemQDAL CatalogueItemQDAL => _lazyCatalogueItemQDAL.Value;

        //private static readonly Lazy<IProductFamilyQDAL> _lazyProductFamilyQDAL = ObjectContainer.LazyResolve<IProductFamilyQDAL>();
        //private IProductFamilyQDAL ProductFamilyQDAL => _lazyProductFamilyQDAL.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  RefreshProductFamilyAsync  -

        public async Task<string> RefreshProductFamilyAsync(RefreshProductFamilyCommand cmd)
        {
            if (cmd.RefreshChangesOnly)
            {
                var changedFamilyIds = cmd.FamilyIDs
                    .Select(async id =>
                    {
                        var family = await ProductFamilyMDAL.GetFamilyWithItemsAsync(id).ConfigureAwait(false);
                        if (family.IsNotNull() && family.Items.IsPresent())
                        {
                            if (family.Flags.HasAnyFlag(ProductFlagsEnum.HasChanges))
                            {
                                return family.ID;
                            }
                        }
                        return null;
                    })
                    .Select(x => x.Result)
                    .Where(x => x.IsNotNull())
                    .ToList();

                if (changedFamilyIds.IsNotNull() && changedFamilyIds.Any())
                {
                    cmd.FamilyIDs = changedFamilyIds;
                }
            }

            if (cmd.FamilyIDs.IsNull()) return MSGCODES.APP_0000000015;
            // ^^^^^^^^^^

            // Run Transactions
            IList<string> msgCodes = new List<string>();
            foreach (var item in cmd.FamilyIDs)
            {
                var tran = new RefreshTransaction(new RefreshProductFamilyCommand { FamilyID = item });
                await tran.RunAsync().ConfigureAwait(false);
                msgCodes.Add(tran.IsSuccess ? MsgCodes.SUCCESS : string.Join("\n", tran.ReadLogs()));
            }
            return string.Join(",", msgCodes);
        }

        #endregion
    }
}
