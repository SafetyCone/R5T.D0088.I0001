using System;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.D0088.I0001.Construction
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddHostStartup(this IServiceCollection services)
        {
            services.AddSingleton<HostStartup>();

            return services;
        }
    }
}
