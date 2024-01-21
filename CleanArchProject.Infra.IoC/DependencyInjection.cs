using CleanArchProject.Application.Interfaces;
using CleanArchProject.Application.Mappings;
using CleanArchProject.Application.Services;
using CleanArchProject.Domain.Interfaces;
using CleanArchProject.Infra.Data.Context;
using CleanArchProject.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchProject.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("CleanArchProject.Application");
            services.AddMediatR(
                x => x.RegisterServicesFromAssembly(typeof(DomainToDTOMappingProfile).Assembly));
            return services;
        }

    }
}
