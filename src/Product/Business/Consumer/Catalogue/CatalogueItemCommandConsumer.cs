using SyncSoft.App.Components;
using SyncSoft.App.Messaging;
using SyncSoft.Olliix.Product.Command.Catalogue;
using SyncSoft.Olliix.Product.Domain.Catalogue;
using System;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Consumer.Catalogue
{
    public class CatalogueItemCommandConsumer
        : IConsumer<GenerateCatalogueItemCommand>
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<ICatalogueItemService> _lazyCatalogueItemService = ObjectContainer.LazyResolve<ICatalogueItemService>();
        private ICatalogueItemService _CatalogueItemService => _lazyCatalogueItemService.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  GenerateCatalogueItemCommand  -

        public async Task<object> HandleAsync(IContext<GenerateCatalogueItemCommand> context)
        {
            var msg = context.Message;

            return await _CatalogueItemService.GenerateByFamilyAsync(msg).ConfigureAwait(false);
        }

        #endregion
    }
}
