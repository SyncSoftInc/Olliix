using NUnit.Framework;
using System;
using System.Data;

namespace DataAccess
{
    public abstract class DALTestBase
    {
        private readonly Lazy<IDbConnection> _lazyConnection = new Lazy<IDbConnection>(() => TestEnv.ProductDB.CreateConnection());
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
