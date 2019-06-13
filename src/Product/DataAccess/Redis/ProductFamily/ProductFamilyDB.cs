using SyncSoft.App.Redis;

namespace SyncSoft.Olliix.Product.Redis.ProductFamily
{
    public class ProductFamilyDB : RedisDB, IProductFamilyDB
    {
        public ProductFamilyDB(string connStrName) : base(connStrName)
        { }
    }
}
