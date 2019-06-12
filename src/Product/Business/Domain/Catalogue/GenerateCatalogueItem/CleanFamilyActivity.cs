using SyncSoft.App.Components;
using SyncSoft.App.Transactions;
using SyncSoft.Olliix.Product.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Domain.Catalogue
{
    public class CleanFamilyActivity : TccActivity
    {
        private static readonly Lazy<ICatalogueItemQDAL> _lazyCatalogueItemQDAL = ObjectContainer.LazyResolve<ICatalogueItemQDAL>();
        private ICatalogueItemQDAL _CatalogueItemQDAL => _lazyCatalogueItemQDAL.Value;

        protected override async Task RunAsync(CancellationToken? cancellationToken)
        {
            var familyId = Context.Get<string>("FamilyID");
            await _CatalogueItemQDAL.DeleteFamilyItemsAsync(familyId).ConfigureAwait(false);
        }

        protected override Task RollbackAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
