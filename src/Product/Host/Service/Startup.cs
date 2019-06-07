using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SyncSoft.App;
using SyncSoft.ECP.AspNetCore.Hosting;

namespace SyncSoft.Olliix.Product.Service
{
    public class Startup : SerilogStartup
    {
        private const string RESOURE_NAME = "olx_product_svc";

        public Startup(IConfiguration configuration)
            : base(configuration)
        {
            OlliixEngine.Init(configuration, o => o.ResourceName = RESOURE_NAME)
                .UseProductRedis()
                .UseProductMySql()
                .UseProductES()
                .UseProductDF()
                .UseProductDomain()
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
