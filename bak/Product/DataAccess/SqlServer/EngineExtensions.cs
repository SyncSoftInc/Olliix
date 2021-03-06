﻿using SyncSoft.App.Components;
using SyncSoft.App.EngineConfigs;
using SyncSoft.Olliix.Product.DataAccess.ProductFamily;
using SyncSoft.Olliix.Product.DataAccess.ProductItem;
using SyncSoft.Olliix.Product.SqlServer;
using SyncSoft.Olliix.Product.SqlServer.ProductFamily;
using SyncSoft.Olliix.Product.SqlServer.ProductItem;
using System;

namespace SyncSoft.App
{
    public static class EngineExtensions
    {
        public static CommonConfigurator UseProductSqlServer(this CommonConfigurator configurator, Action<ProductMySqlOption> configOptions = null, ProductMySqlOption options = null)
        {
            options = options ?? new ProductMySqlOption();
            configOptions?.Invoke(options);

            configurator.Engine.Starting += (o, e) =>
            {
                ObjectContainer.Register<IProductFamilyMDAL, ProductFamilyMDAL>(LifeCycleEnum.Singleton);
                ObjectContainer.Register<IProductItemMDAL, ProductItemMDAL>(LifeCycleEnum.Singleton);
                ObjectContainer.Register<IProductDB>(() => new ProductDB(options.ConnStrName), LifeCycleEnum.Singleton);
            };

            return configurator;
        }
    }
}
