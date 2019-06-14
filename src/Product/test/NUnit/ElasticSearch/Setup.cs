using SyncSoft.App;
using SyncSoft.Olliix;

namespace ElasticSearch
{
    public class Setup : Tests.SetupBase
    {
        public override void Startup()
        {
            OlliixEngine.Init()
                .UseProductES()
                .Start();

            base.Startup();
        }
    }
}
