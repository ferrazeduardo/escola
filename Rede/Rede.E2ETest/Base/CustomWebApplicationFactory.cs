using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Rede.E2ETest.Base;
//criação de um servidor web para testes E2E
public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //configuração especifica para testes
        var environmentName = "EndToEndTest"; 
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT",environmentName);
        builder.UseEnvironment(environmentName);
        builder.ConfigureServices(services =>
        {
            services.AddRedeClient();
        });
        base.ConfigureWebHost(builder);
    }
}