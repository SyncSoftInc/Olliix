using NUnit.Framework;
using SyncSoft.App.Components;
using SyncSoft.Olliix.Product.Command.ProductFamily;
using SyncSoft.Olliix.Product.DataAccess;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductFamily
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IProductFamilyMDAL> _lazyProductFamilyMDAL = ObjectContainer.LazyResolve<IProductFamilyMDAL>();
        private IProductFamilyMDAL _ProductFamilyMDAL => _lazyProductFamilyMDAL.Value;

        #endregion

        [Test]
        public async Task Insert()
        {
            var tasks = Enumerable.Range(1, 200).Select(async i =>
            {
                var cmd = Mock.CreateWithRandomData<CreateProductFamilyCommand>();
                var msgCode = await _ProductFamilyMDAL.InsertAsync(cmd).ConfigureAwait(false);
                Assert.IsTrue(msgCode.IsSuccess());
                return msgCode;
            }).ToArray();

            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}
