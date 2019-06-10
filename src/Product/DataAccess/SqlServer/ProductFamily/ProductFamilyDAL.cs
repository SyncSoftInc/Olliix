using SyncSoft.Olliix.Product.Command.ProductFamily;
using SyncSoft.Olliix.Product.DataAccess;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.SqlServer.ProductFamily
{
    public class ProductFamilyDAL : SyncSoft.ECP.SqlServer.ECPSqlServerDAL, IProductFamilyMDAL
    {
        // *******************************************************************************************************************************
        #region -  Constructor(s)  -

        public ProductFamilyDAL(IProductDB db) : base(db)
        {
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Insert  -

        public async Task<string> InsertAsync(CreateProductFamilyCommand cmd)
        {
            return await base.TryExecuteAsync(
                "INSERT INTO ProductFamilies (ID, Name, Brand) VALUES(@ID, @Name, @Brand)",
                cmd).ConfigureAwait(false);
        }

        #endregion
    }
}