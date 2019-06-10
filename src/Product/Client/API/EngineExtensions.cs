﻿using SyncSoft.App.Components;
using SyncSoft.App.EngineConfigs;
using SyncSoft.Olliix.Product.API;

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
            };

            return configurator;
        }
    }
}
