using SyncSoft.App;
using SyncSoft.Olliix;

namespace API
{
    public class Setup : Tests.SetupBase
    {
        public override void Startup()
        {
            OlliixEngine.Init()
                .UseProductAPI()
                .AsUnitTestApiClient()
                .Start();

            base.Startup();
        }
    }
}
