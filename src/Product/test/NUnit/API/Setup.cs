using NUnit.Framework;
using SyncSoft.App;
using SyncSoft.Olliix;

namespace API
{
    [SetUpFixture]
    public class Setup
    {
        [OneTimeSetUp]
        public static void Startup()
        {
            OlliixEngine.Init()
                .UseProductAPI()
                .AsUnitTestApiClient()
                .Start();
        }
    }
}
