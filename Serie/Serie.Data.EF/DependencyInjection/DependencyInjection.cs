using System;
using Microsoft.Extensions.DependencyInjection;

namespace Serie.Data.EF.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDataEf(this IServiceCollection services)
    {
        return services;
    }
}
