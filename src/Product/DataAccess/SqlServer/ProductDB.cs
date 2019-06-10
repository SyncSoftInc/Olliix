namespace SyncSoft.Olliix.Product.SqlServer
{
    public class ProductDB : SyncSoft.App.SqlServer.SqlServerDatabase, IProductDB
    {
        public ProductDB(string connStrName) : base(connStrName)
        {
        }
    }
}
