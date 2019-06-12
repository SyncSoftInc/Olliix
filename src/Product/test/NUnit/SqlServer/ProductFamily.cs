using Dapper;
using NUnit.Framework;
using SyncSoft.App.Components;
using SyncSoft.Olliix;
using SyncSoft.Olliix.Product.Command.ProductFamily;
using SyncSoft.Olliix.Product.DataAccess.ProductFamily;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SqlServer
{
    public class ProductFamily : DALTestBase
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IProductFamilyMDAL> _lazyProductFamilyMDAL = ObjectContainer.LazyResolve<IProductFamilyMDAL>();
        private IProductFamilyMDAL _ProductFamilyMDAL => _lazyProductFamilyMDAL.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  Field(s)  -



        #endregion

        [Test]
        public async Task Insert()
        {
            var tasks = Enumerable.Range(1, 200).Select(async i =>
            {
                var cmd = Mock.CreateWithRandomData<CreateProductFamilyCommand>();
                cmd.ID = TestUtils.CreateFamilyID(i);
                var msgCode = await _ProductFamilyMDAL.InsertAsync(cmd).ConfigureAwait(false);
                Assert.IsTrue(msgCode.IsSuccess());
                return msgCode;
            }).ToArray();

            await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        [Test, Order(0)]
        public void Cleanup()
        {
            Connection.Execute(sql: $"DELETE FROM ProductFamilies WHERE ID LIKE '{TestUtils.Family_IdPrefix}%'");
        }
    }
}
