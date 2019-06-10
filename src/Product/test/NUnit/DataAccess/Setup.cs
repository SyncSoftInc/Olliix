using NUnit.Framework;
using SyncSoft.App;
using SyncSoft.Olliix;

namespace DataAccess
{
    [SetUpFixture]
    public class Setup
    {
        [OneTimeSetUp]
        public static void Startup()
        {
            OlliixEngine.Init()
                .UseProductSqlServer()
                .UseProductES()
                .UseProductRedis()
                .Start();
        }
    }
}
