using NUnit.Framework;
using System.Threading.Tasks;

namespace API
{
    public class CatalogueItem
    {

        [Test]
        public  Task Insert()
        {
            return Task.CompletedTask;
        }
    }
}
