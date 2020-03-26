using SyncSoft.App;
using SyncSoft.App.EngineConfigs;

namespace SyncSoft.Olliix
{
    public static class AppEngine
    {
        public static CommonConfigurator Init()
        {
            ////////// 启动引擎
            return Engine.Init(o =>
                {
                    o.AssemblyFilters.Clear();    // 由于Android不支持，所以不加载程序集
                    //o.AllowOverridingRegistrations = true;
                })
                .UseMobileQuickSettings()
                .UseOlliixAppComponents();
        }
    }
}
