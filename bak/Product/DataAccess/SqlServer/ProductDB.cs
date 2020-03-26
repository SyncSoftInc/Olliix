using System.Data.Common;

namespace SyncSoft.Olliix.Product.SqlServer
{
    public class ProductDB : SyncSoft.App.SqlServer.SqlServerDatabase, IProductDB
    {
        public ProductDB(string connStrName) : base(connStrName)
        {
        }

        protected override DbConnection CreateDbConnection(string connStr)
        {

            return base.CreateDbConnection(connStr);
        }
    }
}
