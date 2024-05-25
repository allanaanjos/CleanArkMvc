using System;
using CleanArchMvc.Application.Interface;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Interface;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.Ioc
{
    public static class DepecencyInject
    {
       public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
               IConfiguration configure)
            {
               services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(configure.GetConnectionString("Connection"),
                 b => b.MigrationsAssembly("CleanArchMvc.Infra.Data")));


                services.AddScoped<ICategoryRepository, CategoryRepository>();
                services.AddScoped<IProductRepository, ProductRepository>();

                services.AddScoped<ICategoryInterface, CategoryService>();
                services.AddScoped<IProductService, ProductService>();

                services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

                var mediatorHandler = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");
                services.AddMediatR(mediatorHandler);

                return services; 
            }
    }
}