using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;

namespace Rede.E2ETest.Base;
//criação de um servidor web para testes E2E
public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
public readonly string baseUrl = "http://localhost:61000/";
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        
        //configuração especifica para testes
        var environmentName = "EndToEndTest"; 
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT",environmentName);
        builder.UseEnvironment(environmentName);
        builder.ConfigureServices(services =>
        {
            services.AddTransient<HttpMessageHandlerBuilder>(
                sp => new TestServerHttpMessageHandlerBuilder(Server));
            
            services.AddRedeClient()
                .ConfigureHttpClient(client => client.BaseAddress = new Uri($"{baseUrl}graphql"));
        });
        base.ConfigureWebHost(builder);
    }
}