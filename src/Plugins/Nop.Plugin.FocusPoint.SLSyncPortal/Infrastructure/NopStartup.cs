using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.FocusPoint.SLSyncPortal.Services;

namespace Nop.Plugin.FocusPoint.SLSyncPortal.Infrastructure;

public class NopStartup : INopStartup
{
    public int Order => 3000; // Specify the order of execution

    public void Configure(IApplicationBuilder application)
    {
    }

    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        // Register your custom service
        services.AddTransient<IHttpService, HttpService>();
    }
}