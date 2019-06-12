using NUnit.Framework;
using System.Threading.Tasks;

namespace API
{
    public class ProductItem
    {

        [Test]
        public Task Insert()
        {
            return Task.CompletedTask;
        }
    }
}
