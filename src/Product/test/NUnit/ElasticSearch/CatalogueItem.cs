using NUnit.Framework;
using SyncSoft.App.Components;
using SyncSoft.Olliix;
using SyncSoft.Olliix.Product.DataAccess.Catalogue;
using SyncSoft.Olliix.Product.DTO.Catalogue;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch
{
    public class CatalogueItem : DALTestBase
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<ICatalogueItemQDAL> _lazyCatalogueItemQDAL = ObjectContainer.LazyResolve<ICatalogueItemQDAL>();
        private ICatalogueItemQDAL CatalogueItemQDAL => _lazyCatalogueItemQDAL.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  BuilkInsert  -

        [Test]
        public async Task BuilkInsert()
        {
            var items = Enumerable.Range(1, 100).Select(i =>
            {
                var dto = Mock.CreateWithRandomData<CatalogueItemDTO>();
                dto.Family_ID = TestUtils.CreateFamilyID(i / 3 + 1);
                //dto.ItemNo = TestUtils.CreateItemNo(dto.Family_ID, i);
                return dto;
            });

            //var msgCode = await _CatalogueItemQDAL.BulkInsertItemsAsync(items).ConfigureAwait(false);
            //var resp = await ElasticClient.BulkAsync(x => x.Index("catalogue_items").IndexMany(items)).ConfigureAwait(false);
            //Assert.IsTrue(resp.IsValid);

            var msgCode = await CatalogueItemQDAL.BulkInsertItemsAsync(items).ConfigureAwait(false);
            Assert.IsTrue(msgCode.IsSuccess());
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  GetFamilyItems  -

        [Test]
        public async Task GetFamilyItems()
        {
            var list = await CatalogueItemQDAL.GetFamilyItemsAsync("FAMILY001").ConfigureAwait(false);
            Assert.IsTrue(list.Any());
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  GetFamilyItems  -

        [Test]
        public async Task DeleteFamilyItems()
        {
            var list = await CatalogueItemQDAL.DeleteFamilyItemsAsync("FAMILY001").ConfigureAwait(false);
            Assert.IsTrue(list.IsSuccess());
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Search  -

        [Test]
        public async Task Search()
        {
            var resp = await ElasticClient.SearchAsync<CatalogueItemDTO>(x =>
                x.Index("catalogue_items")
                 .Query(q => q.Prefix("Family_ID", $"{TestUtils.Family_IdPrefix.ToLower()}"))
            ).ConfigureAwait(false);
            var list = resp.Documents.ToList();
            Assert.IsTrue(list.Any());

            await CatalogueItemQDAL.SearchAsync();
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Cleanup  -

        [Test, Order(0)]
        public void Cleanup()
        {
            var resp = ElasticClient.DeleteByQuery<CatalogueItemDTO>(x =>
                x.Index("catalogue_items")
                 .Query(q => q.Prefix("Family_ID", $"{TestUtils.Family_IdPrefix.ToLower()}"))
            );
            Assert.IsTrue(resp.IsValid);
        }

        #endregion
    }
}
