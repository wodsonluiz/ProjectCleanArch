using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectCleanArch.Application.Interfaces;
using ProjectCleanArch.Application.Mappings;
using ProjectCleanArch.Application.Services;
using ProjectCleanArch.Data.Context;
using ProjectCleanArch.Data.Repositories;
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

            //Repository
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            //Application
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            //AutoMapper
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //Mediator
            var myHandlers = AppDomain.CurrentDomain.Load("ProjectCleanArch.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}