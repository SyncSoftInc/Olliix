using SyncSoft.App.Components;
using SyncSoft.App.Logging;
using SyncSoft.App.Transactions;
using SyncSoft.Olliix.Product.Command.ProductFamily;
using System;
using System.Collections.Generic;

namespace SyncSoft.Olliix.Product.Domain.ProductFamily.Refresh
{
    public class RefreshTransaction : TccTransaction
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<ILogger> _lazyLogger = ObjectContainer.LazyResolveLogger<string>();
        public override ILogger Logger => _lazyLogger.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  Constructor(s)  -

        public RefreshTransaction(RefreshProductFamilyCommand command)
            : base(command.CorrelationId)
        {
            Context.Set("FamilyID", command.FamilyID);
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  BuildActivities  -

        protected override IEnumerable<TransactionActivity> BuildActivities()
        {
            yield return new CleanCatalogueItemActivity();
            yield return new GenerateItemsActivity();
            yield return new RemoveFlagActivity();
        }

        #endregion
    }
}
