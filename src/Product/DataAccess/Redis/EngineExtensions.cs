using SyncSoft.App.Components;
using SyncSoft.App.EngineConfigs;
using SyncSoft.Olliix.Product.DataAccess.ProductFamily;
using SyncSoft.Olliix.Product.Redis.ProductFamily;

namespace SyncSoft.App
{
    public static class EngineExtensions
    {
        public static CommonConfigurator UseProductRedis(this CommonConfigurator configurator)
        {
            configurator.Engine.Starting += (o, e) =>
            {
                ObjectContainer.Register<IProductFamilyDB, ProductFamilyDB>(LifeCycleEnum.Singleton);
                ObjectContainer.Register<IProductFamilyQDAL, ProductFamilyQDAL>(LifeCycleEnum.Singleton);
            };

            return configurator;
        }
    }
}
