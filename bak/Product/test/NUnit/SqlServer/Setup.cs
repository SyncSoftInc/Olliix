using SyncSoft.App;
using SyncSoft.Olliix;

namespace SqlServer
{
    public class Setup : Tests.SetupBase
    {
        public override void Startup()
        {
            OlliixEngine.Init()
                .UseProductSqlServer()
                .Start();

            base.Startup();
        }
    }
}
