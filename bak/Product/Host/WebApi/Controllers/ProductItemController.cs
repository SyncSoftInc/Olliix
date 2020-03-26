using Microsoft.AspNetCore.Mvc;
using SyncSoft.App.Components;
using SyncSoft.ECP.AspNetCore.Mvc.Controllers;
using SyncSoft.Olliix.Product.Command.ProductItem;
using SyncSoft.Olliix.Product.DataFacade.ProductItem;
using System;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.WebApi.Controllers
{
    public class ProductItemController : ApiController
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IProductItemDF> _lazyProductItemDF = ObjectContainer.LazyResolve<IProductItemDF>();
        private IProductItemDF _ProductItemDF => _lazyProductItemDF.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  CreateProductItem  -

        [HttpPost("product/item")]
        public async Task<string> CreateProductItemAsync(CreateProductItemCommand cmd)
        {
            return await RequestAsync(cmd).ConfigureAwait(false);
        }

        #endregion
    }

}
