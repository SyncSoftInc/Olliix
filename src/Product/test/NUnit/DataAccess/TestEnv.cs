using SyncSoft.App.Components;
using SyncSoft.Olliix.Product.SqlServer;
using System;

namespace DataAccess
{
    internal static class TestEnv
    {
        private static readonly Lazy<IProductDB> _lazyProductDB = ObjectContainer.LazyResolve<IProductDB>();
        public static IProductDB ProductDB => _lazyProductDB.Value;

        public const string Family_IdPrefix = "Family-";
        public const string Item_IdPrefix = "Item-";
    }
}
