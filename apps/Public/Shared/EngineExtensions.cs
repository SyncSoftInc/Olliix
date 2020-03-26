using SyncSoft.App.Components;
using SyncSoft.App.EngineConfigs;
using SyncSoft.ECP.Mobile.UI;
using SyncSoft.ECP.Settings;
using SyncSoft.Olliix.Components;

namespace SyncSoft.App
{
    public static class EngineExtensions
    {
        public static CommonConfigurator UseOlliixAppComponents(this CommonConfigurator configurator)
        {
            Engine.PreventDuplicateRegistration(nameof(UseOlliixAppComponents));

            configurator.Engine.Starting += (o, e) =>
            {
                ObjectContainer.Register<IUICoordinator, OlliixAppUICoordinator>(LifeCycleEnum.Singleton);
            };

            return configurator;
        }

        public static ConfigurationConfigurator UseOlliixAppConfigurations(this CommonConfigurator configurator)
        {
            Engine.PreventDuplicateRegistration(nameof(UseOlliixAppConfigurations));

            return configurator.UseJsonConfiguration(o =>
            {
                o.ConfigFiles.Clear();
#if (DEBUG || TEST)
                o.ConfigFiles.Add("SyncSoft.Olliix.appsettings.Development.json, SyncSoft.Olliix");
#else
                o.ConfigFiles.Add("SyncSoft.Olliix.appsettings.json, SyncSoft.Olliix");
#endif
            });
        }
    }
}