using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using SyncSoft.App.Components;
using System;

namespace Tests
{
    [SetUpFixture]
    public class SetupBase
    {
        private static readonly Lazy<IConfiguration> _lazyConfiguration = ObjectContainer.LazyResolve<IConfiguration>();
        private IConfiguration Configuration => _lazyConfiguration.Value;

        [OneTimeSetUp]
        public virtual void Startup()
        {
            var a = Configuration.GetValue<string>("ConnectionStrings:PROVIDER_CONNSTRS");
            Environment.SetEnvironmentVariable("PROVIDER_CONNSTRS", a);
        }
    }
}
