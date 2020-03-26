using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SyncSoft.App;
using SyncSoft.ECP.AspNetCore.Hosting;

namespace SyncSoft.Olliix.Product.WebApi
{
    public class Startup : SerilogStartup
    {
        private const string RESOURE_NAME = "olx_product_api_v1";

        public Startup(IConfiguration configuration)
            : base(configuration)
        {
            OlliixEngine.Init(configuration, o =>
            {
                o.ResourceName = RESOURE_NAME;
                o.UseRabbitMQ = true;
            })
                .UseProductRedis()
                .UseProductSqlServer()
                .UseProductES()
                .UseProductDF()
                .UseProductDomain()
                .UseQuartz()
                .Start();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiServer(RESOURE_NAME);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseReverseProxy();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseApiServer(RESOURE_NAME);
        }
    }
}
