﻿using Dapper;
using SyncSoft.Olliix.Product.Command.ProductItem;
using SyncSoft.Olliix.Product.DataAccess;
using SyncSoft.Olliix.Product.MySql.DB;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.MySql.ProductItem
{
    public class ProductItemDAL : SyncSoft.ECP.MySql.ECPMySqlDAL, IProductItemMDAL
    {
        // *******************************************************************************************************************************
        #region -  Constructor(s)  -

        public ProductItemDAL(IProductDB db) : base(db)
        {
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Insert  -

        public async Task<string> InsertAsync(CreateProductItemCommand cmd)
        {
            var para = new DynamicParameters();

            para.Add("ItemNo", cmd.ItemNo);
            para.Add("Family_ID", cmd.Family_ID);
            para.Add("Size", cmd.Size);
            para.Add("Color", cmd.Color);
            para.Add("ImageHash", cmd.ImageHash);
            para.Add("ImageUrl", cmd.ImageUrl);
            para.Add("UPC", cmd.UPC);
            para.Add("Description", cmd.Description);
            para.Add("ProductDetails", cmd.ProductDetails);
            para.Add("MaterialDetails", cmd.MaterialDetails);
            para.Add("CareInstructions", cmd.CareInstructions);
            para.Add("MSRPrice", cmd.MSRPrice);
            para.Add("Price", cmd.Price);
            para.Add("Length", cmd.Length);
            para.Add("Width", cmd.Width);
            para.Add("Height", cmd.Height);
            para.Add("Status", cmd.Status);

            throw new System.NotImplementedException();
        }

        #endregion
    }
}