namespace SyncSoft.Olliix.Product.MySql.DB
{
    public class ProductDB : SyncSoft.App.MySql.MySqlDatabase, IProductDB
    {
        public ProductDB(string connStrName) : base(connStrName)
        {
        }
    }
}
