using SyncSoft.App.Components;
using SyncSoft.App.Messaging;
using SyncSoft.Olliix.Product.Command.ProductFamily;
using SyncSoft.Olliix.Product.Domain.ProductFamily;
using System;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Consumer.ProductFamily
{
    public class ProductFamilyCommandConsumer
        : IConsumer<RefreshProductFamilyCommand>
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IProductFamilyService> _lazyProductFamilyService = ObjectContainer.LazyResolve<IProductFamilyService>();
        private IProductFamilyService ProductFamilyService => _lazyProductFamilyService.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  GenerateCatalogueItemCommand  -

        public async Task<object> HandleAsync(IContext<RefreshProductFamilyCommand> context)
        {
            var msg = context.Message;

            return await ProductFamilyService.RefreshProductFamilyAsync(msg).ConfigureAwait(false);
        }

        #endregion
    }
}
