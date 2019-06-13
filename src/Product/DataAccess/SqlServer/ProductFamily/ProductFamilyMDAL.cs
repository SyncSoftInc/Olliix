﻿using SyncSoft.Olliix.Product.Command.ProductFamily;
using SyncSoft.Olliix.Product.DataAccess.ProductFamily;
using SyncSoft.Olliix.Product.DTO.ProductFamily;
using SyncSoft.Olliix.Product.DTO.ProductItem;
using System.Linq;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.SqlServer.ProductFamily
{
    public class ProductFamilyMDAL : SyncSoft.ECP.SqlServer.ECPSqlServerDAL, IProductFamilyMDAL
    {
        // *******************************************************************************************************************************
        #region -  Constructor(s)  -

        public ProductFamilyMDAL(IProductDB db) : base(db)
        {
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  CURD  -

        public async Task<string> InsertAsync(CreateProductFamilyCommand cmd)
        {
            return await base.TryExecuteAsync(
                "INSERT INTO ProductFamilies (ID, Name, Brand, Room) VALUES(@ID, @Name, @Brand, @Room)",
                cmd).ConfigureAwait(false);
        }

        public async Task<string> UpdateAsync(ProductFamilyDTO dto)
        {
            return await base.TryExecuteAsync(
@"UPDATE [ProductFamilies] SET 
ID = @ID
, Name = @Name
, Brand = @Brand
, Room = @Room
, Flags = @Flags
WHERE ID = @ID", dto).ConfigureAwait(false);
        }

        public async Task<ProductFamilyDTO> GetFamilyAsync(string id)
        {
            var query = await base.TryQueryFirstOrDefaultAsync<ProductFamilyDTO>("SELECT * FROM [ProductFamilies] WHERE ID = @ID", new
            {
                ID = id
            }).ConfigureAwait(false);
            return query.Result;
        }

        public async Task<ProductFamilyDTO> GetFamilyWithItemsAsync(string familyId)
        {
            var itemsMr = await base.TryQueryListAsync<ProductItemDTO>("SELECT * FROM V_ProductFamilyItems WHERE Family_ID = @FamilyID"
            , new
            {
                FamilyID = familyId
            }).ConfigureAwait(false);

            if (itemsMr.Result.IsPresent())
            {
                var familyDto = new ProductFamilyDTO();
                itemsMr.Result.Aggregate(familyDto, (f, i) =>
                {
                    f.Name = i.Name;
                    f.Brand = i.Brand;
                    f.Room = i.Room;
                    f.Items.Add(i);
                    return f;
                });
                return familyDto;
            }

            return null;
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  RemoveFlags  -

        public async Task<string> RemoveFlagAsync(string id, int flag)
        {
            return await base.TryExecuteAsync("UPDATE [ProductFamilies] SET Flags = Flags ^ @Flag WHERE ID = @ID", new
            {
                ID = id,
                Flag = flag
            }).ConfigureAwait(false);
        }

        #endregion
    }
}