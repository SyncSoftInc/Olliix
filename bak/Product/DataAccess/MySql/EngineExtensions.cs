using SyncSoft.App.Components;
using SyncSoft.App.EngineConfigs;
using SyncSoft.Olliix.Product.DataAccess;
using SyncSoft.Olliix.Product.MySql;
using SyncSoft.Olliix.Product.MySql.DB;
using SyncSoft.Olliix.Product.MySql.ProductItem;
using System;

namespace SyncSoft.App
{
    public static class EngineExtensions
    {
        public static CommonConfigurator UseProductMySql(this CommonConfigurator configurator, Action<ProductMySqlOption> configOptions = null, ProductMySqlOption options = null)
        {
            options = options ?? new ProductMySqlOption();
            configOptions?.Invoke(options);

            configurator.Engine.Starting += (o, e) =>
            {
                ObjectContainer.Register<IProductItemMDAL, ProductItemDAL>(LifeCycleEnum.Singleton);
                ObjectContainer.Register<IProductDB>(() => new ProductDB(options.ConnStrName), LifeCycleEnum.Singleton);
            };

            return configurator;
        }
    }
}
