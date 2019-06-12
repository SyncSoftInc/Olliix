using NUnit.Framework;
using SyncSoft.App;
using SyncSoft.Olliix;

namespace ElasticSearch
{
    [SetUpFixture]
    public class Setup
    {
        [OneTimeSetUp]
        public static void Startup()
        {
            OlliixEngine.Init()
                .UseProductES()
                .Start();
        }
    }
}
