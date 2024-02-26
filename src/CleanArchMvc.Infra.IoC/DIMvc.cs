using CleanArchMvc.Domain.Auth.Interfaces;
using CleanArchMvc.Infra.Data.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC
{
    public static class DIMvc
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddCommonInfrastructure(configuration);

            services.ConfigureApplicationCookie(options =>
                options.AccessDeniedPath = "/Account/Login");

            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            return services;
        }
    }
}
