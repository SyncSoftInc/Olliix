using Microsoft.AspNetCore.Mvc;
using SyncSoft.App.Components;
using SyncSoft.ECP.AspNetCore.Mvc.Controllers;
using SyncSoft.Olliix.Product.Command.ProductFamily;
using SyncSoft.Olliix.Product.DataFacade.ProductItem;
using SyncSoft.Olliix.Product.DTO.ProductFamily;
using System;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.WebApi.Controllers
{
    public class ProductFamilyController : ApiController
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
        #region -  CreateProductFamily  -

        [HttpPost("product/family")]
        public async Task<string> CreateProductItemAsync(CreateProductFamilyCommand cmd)
        {
            return await RequestAsync(cmd).ConfigureAwait(false);
        }

        #endregion
    }

}
