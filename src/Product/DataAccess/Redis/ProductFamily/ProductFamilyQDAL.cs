using SyncSoft.App.Components;
using SyncSoft.App.Json;
using SyncSoft.Olliix.Product.DataAccess.ProductFamily;
using SyncSoft.Olliix.Product.DTO.ProductFamily;
using System;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Redis.ProductFamily
{
    public class ProductFamilyQDAL : IProductFamilyQDAL
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IJsonSerializer> _lazyJsonSerializer = ObjectContainer.LazyResolve<IJsonSerializer>();
        private IJsonSerializer JsonSerializer => _lazyJsonSerializer.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  Field(s)  -

        private readonly IProductFamilyDB _db;
        private const string KEY = "olx:Product:Families";

        #endregion
        // *******************************************************************************************************************************
        #region -  Constructor(s)  -

        public ProductFamilyQDAL(IProductFamilyDB db)
        {
            _db = db;
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  GetFamily  -

        public async Task<ProductFamilyDTO> GetFamilyAsync(string familyId)
        {
            return await _db.HGetAsync<ProductFamilyDTO>(KEY, familyId).ConfigureAwait(false);
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  SaveFamily  -

        public async Task<string> SaveFamilyAsync(ProductFamilyDTO dto)
        {
            var json = JsonSerializer.Serialize(dto);
            await _db.HSetAsync(KEY, dto.ID, json).ConfigureAwait(false);
            return MsgCodes.SUCCESS;
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  DeleteFamily  -

        public async Task<string> DeleteFamilyAsync(string familyId)
        {
            await _db.HDelAsync(KEY, familyId).ConfigureAwait(false);
            return MsgCodes.SUCCESS;
        }

        #endregion
    }
}
