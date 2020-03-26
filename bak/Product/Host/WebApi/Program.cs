using SyncSoft.ECP.Quartz.Hosting;

namespace SyncSoft.Olliix.Product.WebApi
{
    public class Program
    {
        public static void Main(string[] args) => QuartzHost.Run<Startup>(args);
    }
}
