namespace Pessoa.Api.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConfiguration>(_ => configuration);
        return services;
    }

    public static IServiceCollection ResolverDependencyInjectionCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

                });
        });
        
        return services;
    }
}