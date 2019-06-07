using SyncSoft.App.EngineConfigs;

namespace SyncSoft.App
{
    public static class EngineExtensions
    {
        public static CommonConfigurator UseProductRedis(this CommonConfigurator configurator)
        {
            configurator.Engine.Starting += (o, e) =>
            {
            };

            return configurator;
        }
    }
}
