using NUnit.Framework;
using SyncSoft.App.Components;
using SyncSoft.Olliix.Product.SqlServer;
using System;
using System.Data;

namespace SqlServer
{
    public abstract class DALTestBase
    {
        private readonly Lazy<IDbConnection> _lazyConnection = new Lazy<IDbConnection>(() =>
            ObjectContainer.Resolve<IProductDB>().CreateConnection());
        protected IDbConnection Connection => _lazyConnection.Value;

        [TearDown]
        public void TearDown()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}
