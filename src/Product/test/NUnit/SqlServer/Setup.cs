using NUnit.Framework;
using SyncSoft.App;
using SyncSoft.Olliix;

namespace SqlServer
{
    [SetUpFixture]
    public class Setup
    {
        [OneTimeSetUp]
        public static void Startup()
        {
            OlliixEngine.Init()
                .UseProductSqlServer()
                .Start();
        }
    }
}
