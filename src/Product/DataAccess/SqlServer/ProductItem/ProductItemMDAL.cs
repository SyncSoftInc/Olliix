using Dapper;
using SyncSoft.Olliix.Product.Command.ProductItem;
using SyncSoft.Olliix.Product.DataAccess.ProductItem;
using System.Data;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.SqlServer.ProductItem
{
    public class ProductItemMDAL : SyncSoft.ECP.SqlServer.ECPSqlServerDAL, IProductItemMDAL
    {
        // *******************************************************************************************************************************
        #region -  Constructor(s)  -

        public ProductItemMDAL(IProductDB db) : base(db)
        {
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Insert  -

        public async Task<string> InsertAsync(CreateProductItemCommand cmd)
        {
            var para = new DynamicParameters();

            para.Add("@ItemNo", cmd.ItemNo);
            para.Add("@Family_ID", cmd.Family_ID);
            para.Add("@Size", cmd.Size);
            para.Add("@Color", cmd.Color);
            para.Add("@ImageHash", cmd.ImageHash);
            para.Add("@ImageUrl", cmd.ImageUrl);
            para.Add("@UPC", cmd.UPC);
            para.Add("@Description", cmd.Description);
            para.Add("@ProductDetails", cmd.ProductDetails);
            para.Add("@MaterialDetails", cmd.MaterialDetails);
            para.Add("@CareInstructions", cmd.CareInstructions);
            para.Add("@MSRPrice", cmd.MSRPrice);
            para.Add("@Price", cmd.Price);
            para.Add("@Length", cmd.Length);
            para.Add("@Width", cmd.Width);
            para.Add("@Height", cmd.Height);
            para.Add("@Flags", cmd.Flags);

            return await base.TryExecuteAsync("PRDSP_InsertItem", para, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        }

        #endregion
    }
}