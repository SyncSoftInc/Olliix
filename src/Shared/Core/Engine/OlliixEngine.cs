using Microsoft.Extensions.Configuration;
using SyncSoft.App;
using SyncSoft.App.EngineConfigs;
using SyncSoft.App.Redis.Confgiguration;
using SyncSoft.App.Redis.Messaging;
using SyncSoft.App.Redis.Transaction;
using SyncSoft.App.Securities;
using SyncSoft.ECP.Securities;
using System;

namespace SyncSoft.Olliix
{
    public static class OlliixEngine
    {
        public static CommonConfigurator Init(IConfiguration configuration = null,
                                              Action<OlliixEngineOption> configOptions = null,
                                              OlliixEngineOption options = null)
        {
            options = options ?? new OlliixEngineOption();
            configOptions?.Invoke(options);

            var configurator = Engine.Init(o =>
            {
                o.Configuration = configuration;
                o.AllowOverridingRegistrations = options.AllowOverridingRegistrations;
            })
                .UseECPSeriglogLoggerQuickSettings(o =>
                {
                    o.ConfigSerilogLoggerAppQuickSettingOptions = b =>
                    {
                        b.ConfigAppDefaultComponentsOptions = d =>
                        {
                            d.ConnectionStringProviderType = typeof(RedisConnectionStringProvider);
                            d.MsgResultStoreType = typeof(RedisMsgResultStore);
                            d.TransactionStateStoreType = typeof(RedisTransactionStateStore);
                        };
                    };
                    o.ConfigECPSecurityComponentsOptions = a =>
                    {
                        a.CoreCertProviderType = typeof(ConfigurationCoreCertProvider);
                        a.PasswordEncryptorType = typeof(Sha256PasswordEncryptor);
                    };
                })
                .UseECPAspNetCore(options.ResourceName);

            if (options.UseRabbitMQ)
            {
                configurator
                    .UseMessageQueue()
                    .UseRabbitMQ();
            }
            else
            {
                configurator
                    .UseMessageQueue()
                    .UseDefaultMessageComponents();
            }

            configurator.UseECPRedis();

            return configurator;
        }
    }
}
