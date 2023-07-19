using Nop.Core.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Nop.Plugin.FocusPoint.SLSyncPortal.Services;
using Nop.Plugin.FocusPoint.SLSyncPortal.Servies;

namespace Nop.Plugin.FocusPoint.SLSyncPortal
{
    public class MyPluginStartup : INopStartup
    {
        public int Order =>3000; // Specify the order of execution

        public void Configure(IApplicationBuilder application)
        {

        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Register your custom service
            services.AddTransient<IHttpService, HttpService>();
        }
    }
}