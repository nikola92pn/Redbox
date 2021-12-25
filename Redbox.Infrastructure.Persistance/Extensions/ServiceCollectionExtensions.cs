using Microsoft.Extensions.DependencyInjection;
using Redbox.Core.Database;
using Redbox.Core.Entities;
using Redbox.Core.Repositories;
using Redbox.Infrastructure.Persistance.Context;
using Redbox.Infrastructure.Persistance.DataGenerators;
using Redbox.Infrastructure.Persistance.Repositories;

namespace Redbox.Infrastructure.Persistance.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistance(this IServiceCollection services)
        {
            services.AddDbContext<RedboxDbContext>();
            services.AddScoped<IDataGenerator, DataGenerator>();

            services.AddScoped<IRepository<Item>, ItemRepository>();
            services.AddScoped<IRepository<Cart>, CartRepository>();
            services.AddScoped<IRepository<CartItem>, CartItemRepository>();
        }
    }
}
