using SyncSoft.App.Components;
using SyncSoft.Olliix.Product.DataAccess.ProductFamily;
using SyncSoft.Olliix.Product.DTO.ProductFamily;
using System;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.DataFacade.ProductFamily
{
    public class ProductFamilyDF : IProductFamilyDF
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IProductFamilyQDAL> _lazyProductFamilyQDAL = ObjectContainer.LazyResolve<IProductFamilyQDAL>();
        private IProductFamilyQDAL ProductFamilyQDAL => _lazyProductFamilyQDAL.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  GetProductFamily  -

        public Task<ProductFamilyDTO> GetProductFamilyAsync(string familyId)
        {
            return ProductFamilyQDAL.GetFamilyAsync(familyId);
        }

        #endregion
    }
}
