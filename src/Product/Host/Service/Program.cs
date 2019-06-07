using SyncSoft.ECP.AspNetCore.Hosting;

namespace SyncSoft.Olliix.Product.Service
{
    public class Program
    {
        public static void Main(string[] args) => ECPHost.Run<Startup>(args);
    }
}
