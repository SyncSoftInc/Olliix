using Microsoft.AspNetCore.Mvc;
using SyncSoft.App.Components;
using SyncSoft.ECP.AspNetCore.Mvc.Controllers;
using SyncSoft.Olliix.Product.Command.ProductItem;
using SyncSoft.Olliix.Product.DataFacade;
using SyncSoft.Olliix.Product.DTO;
using System;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Service.Controllers
{
    public class ProductController : ApiController
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IProductItemDF> _lazyProductItemDF = ObjectContainer.LazyResolve<IProductItemDF>();
        private IProductItemDF _ProductItemDF => _lazyProductItemDF.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  GetProductFamily  -

        [HttpGet("product/family/{famliyId}")]
        public async Task<ProductFamilyDTO> GetProductFamilyAsync(string famliyId)
        {
            return await _ProductItemDF.GetProductFamilyAsync(famliyId).ConfigureAwait(false);
        }

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
