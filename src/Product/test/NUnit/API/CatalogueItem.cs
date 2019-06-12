using NUnit.Framework;
using SyncSoft.App.Components;
using SyncSoft.Olliix.Product.API.Catalogue;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class CatalogueItem
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<ICatalogueItemApi> _lazyCatalogueItemApi = ObjectContainer.LazyResolve<ICatalogueItemApi>();
        private ICatalogueItemApi _CatalogueItemApi => _lazyCatalogueItemApi.Value;

        #endregion

        [Test]
        public async Task Generate()
        {
            var hr = await _CatalogueItemApi.GenerateFamilyItemsAsync(new { FamilyID = "11111" }).ConfigureAwait(false);
            var msgCodes = await hr.GetResultAsync().ConfigureAwait(false);
            msgCodes.ForEach(x =>
            {
                Assert.IsTrue(x.IsSuccess());
            });
        }
    }
}
