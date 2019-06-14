using NUnit.Framework;
using SyncSoft.App.Components;
using SyncSoft.Olliix.Product.API.ProductFamily;
using System;
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

    public class ProductFamily
    {
        private static readonly Lazy<IProductFamilyApi> _lazyProductFamilyApi = ObjectContainer.LazyResolve<IProductFamilyApi>();
        private IProductFamilyApi ProductFamilyApi => _lazyProductFamilyApi.Value;

        [Test]
        public Task Refresh()
        {
            return ProductFamilyApi.RefreshAsync("FAMILY011");
        }
    }
}
