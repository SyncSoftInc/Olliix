using SyncSoft.App.Components;
using SyncSoft.App.EngineConfigs;
using SyncSoft.Olliix.Product.API;
using SyncSoft.Olliix.Product.API.Catalogue;
using SyncSoft.Olliix.Product.API.ProductFamily;
using SyncSoft.Olliix.Product.API.ProductItem;

namespace SyncSoft.App
{
    public static class EngineExtensions
    {
        public static CommonConfigurator UseProductAPI(this CommonConfigurator configurator)
        {
            configurator.Engine.Starting += (o, e) =>
            {
                ObjectContainer.Register<IProductItemApi, ProductItemApi>(LifeCycleEnum.Singleton);
                ObjectContainer.Register<IProductFamilyApi, ProductFamilyApi>(LifeCycleEnum.Singleton);
                ObjectContainer.Register<ICatalogueItemApi, CatalogueItemApi>(LifeCycleEnum.Singleton);
            };

            return configurator;
        }
    }
}
