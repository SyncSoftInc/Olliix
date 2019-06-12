using SyncSoft.App.Components;
using SyncSoft.App.Logging;
using SyncSoft.App.Transactions;
using SyncSoft.Olliix.Product.Command.Catalogue;
using System;
using System.Collections.Generic;

namespace SyncSoft.Olliix.Product.Domain.Catalogue
{
    public class Transaction : TccTransaction
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<ILogger> _lazyLogger = ObjectContainer.LazyResolveLogger<string>();
        public override ILogger Logger => _lazyLogger.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  Constructor(s)  -

        public Transaction(GenerateCatalogueItemCommand command)
            : base(command.CorrelationId)
        {
            Context.Set("FamilyID", command.FamilyID);
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  BuildActivities  -

        protected override IEnumerable<TransactionActivity> BuildActivities()
        {
            yield return new CleanFamilyActivity();
            yield return new GenerateItemsActivity();
        }

        #endregion
    }
}
