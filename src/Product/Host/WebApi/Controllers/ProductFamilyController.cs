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

        [HttpGet("product/family/{familyId}")]
        public async Task<ProductFamilyDTO> GetProductFamilyAsync(string familyId)
        {
            return await _ProductItemDF.GetProductFamilyAsync(familyId).ConfigureAwait(false);
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  RefreshProductFamily  -


        [HttpPut("product/family/{familyId}")]
        public async Task<string> RefreshProductFamilyAsync(string familyId)
        {
            var cmd = new RefreshProductFamilyCommand { FamilyID = familyId };
            return await SendAsync(cmd).ConfigureAwait(false);
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
