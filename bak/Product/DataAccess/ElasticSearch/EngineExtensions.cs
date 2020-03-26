using SyncSoft.App.Components;
using SyncSoft.App.EngineConfigs;
using SyncSoft.Olliix.Product.DataAccess.Catalogue;
using SyncSoft.Olliix.Product.ElasticSearch.Catalogue;

namespace SyncSoft.App
{
    public static class EngineExtensions
    {
        public static CommonConfigurator UseProductES(this CommonConfigurator configurator)
        {
            configurator.UseElasticSearch();

            configurator.Engine.Starting += (o, e) =>
            {
                ObjectContainer.Register<ICatalogueItemQDAL, CatalogueItemQDAL>(LifeCycleEnum.Singleton);
            };

            return configurator;
        }
    }
}
