using SyncSoft.App.Components;
using SyncSoft.Olliix.Product.API.Catalogue;
using System;

namespace API
{
    public class CatalogueItem
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<ICatalogueItemApi> _lazyCatalogueItemApi = ObjectContainer.LazyResolve<ICatalogueItemApi>();
        private ICatalogueItemApi CatalogueItemApi => _lazyCatalogueItemApi.Value;

        #endregion

        //[Test]
        //public async Task GenerateFamilyItems()
        //{
        //    var hr = await CatalogueItemApi.GenerateFamilyItemsAsync(new { FamilyID = "FAMILY011" }).ConfigureAwait(false);
        //    var msgCode = await hr.GetResultAsync().ConfigureAwait(false);
        //    Assert.IsTrue(msgCode.IsSuccess());
        //}
    }
}
