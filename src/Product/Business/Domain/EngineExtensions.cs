using SyncSoft.App.Components;
using SyncSoft.App.EngineConfigs;
using SyncSoft.Olliix.Product.Domain.Catalogue;
using SyncSoft.Olliix.Product.Domain.ProductItem;

namespace SyncSoft.App
{
    public static class EngineExtensions
    {
        public static CommonConfigurator UseProductDomain(this CommonConfigurator configurator)
        {
            configurator.Engine.Starting += (o, e) =>
            {
                ObjectContainer.Register<IProductItemService, ProductItemService>(LifeCycleEnum.Singleton);
                ObjectContainer.Register<ICatalogueItemService, CatalogueItemService>(LifeCycleEnum.Singleton);
            };

            return configurator;
        }
    }
}
