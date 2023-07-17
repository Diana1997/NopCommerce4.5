using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;

namespace Nop.Plugin.FocusPoint.SLSyncPortal
{
    public class MyPluginStartup : INopStartup
    {
        public int Order => 0; // Specify the order of execution

        public void Configure(IApplicationBuilder application)
        {

        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Register your custom service
           // services.AddScoped<IMyCustomService, MyCustomService>();
        }
    }
}