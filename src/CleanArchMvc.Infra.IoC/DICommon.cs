
using AutoMapper;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Auth.Interfaces;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Identity;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace CleanArchMvc.Infra.IoC
{
    public static class DICommon
    {
        public static IServiceCollection AddCommonInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var sqliteFolderPath = GetSqliteFolderPath();
            var appContextConnectionString = string.Format(configuration.GetConnectionString("DefaultConnection"), sqliteFolderPath);
            var identityContextConnectionString = string.Format(configuration.GetConnectionString("IdentityConnection"), sqliteFolderPath);

            #region Contexts
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(appContextConnectionString,
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlite(identityContextConnectionString));
            #endregion

            #region Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();
            #endregion

            #region Application Services
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
            #endregion

            return services;
        }

        private static string GetSqliteFolderPath()
        {
            var srcPath = Directory.GetParent(Environment.CurrentDirectory).FullName;
            var databaseFolderPath = Path.Combine(srcPath, "Data");

            if (!Directory.Exists(databaseFolderPath)) Directory.CreateDirectory(databaseFolderPath);

            return databaseFolderPath;
        }

    }
}
