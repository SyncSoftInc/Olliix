using NUnit.Framework;
using SyncSoft.App.Components;
using SyncSoft.Olliix.Product.Command.ProductItem;
using SyncSoft.Olliix.Product.DataAccess;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductItem
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IProductItemMDAL> _lazyProductItemMDAL = ObjectContainer.LazyResolve<IProductItemMDAL>();
        private IProductItemMDAL _ProductItemMDAL => _lazyProductItemMDAL.Value;

        #endregion

        [Test]
        public async Task Insert()
        {

            var tasks = Enumerable.Range(1, 1).Select(async i =>
            {
                var cmd = Mock.CreateWithRandomData<CreateProductItemCommand>();
                var msgCode = await _ProductItemMDAL.InsertAsync(cmd).ConfigureAwait(false);
                Assert.IsTrue(msgCode.IsSuccess());
                return msgCode;
            }).ToArray();

            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}
