using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetShop.DA.DataContext;
using PetShop.DA.Repositories;
using PetShop.DA.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.DA
{
    public static class DataAccessLayerServiceRegistration
    {
        public static IServiceCollection AddDataAccessLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options =>
            {
                options.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
            }));

            services.AddScoped<DataInitializer>();

            services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    }
}
