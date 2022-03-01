using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectCleanArch.Application.Interfaces;
using ProjectCleanArch.Application.Mappings;
using ProjectCleanArch.Application.Services;
using ProjectCleanArch.Data.Context;
using ProjectCleanArch.Data.Identity;
using ProjectCleanArch.Data.Repositories;
using ProjectCleanArch.Domain.Auth;
using ProjectCleanArch.Domain.Interfaces;
using System;

namespace ProjectCleanArch.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrasTructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitialService>();

            //Repository
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            //Application
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            //AutoMapper
            services.AddAutoMapper(typeof(DomainToDTO));
            services.AddAutoMapper(typeof(DTOToCommand));

            //Mediator
            var myHandlers = AppDomain.CurrentDomain.Load("ProjectCleanArch.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}