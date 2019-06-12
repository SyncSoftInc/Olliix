using Nest;
using SyncSoft.App.Components;
using System;

namespace ElasticSearch
{
    public abstract class DALTestBase
    {
        private static readonly Lazy<IElasticClient> _lazyElasticClient = ObjectContainer.LazyResolve<IElasticClient>();
        protected IElasticClient ElasticClient => _lazyElasticClient.Value;
    }
}
