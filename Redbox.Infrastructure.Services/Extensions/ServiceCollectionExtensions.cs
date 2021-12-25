using Microsoft.Extensions.DependencyInjection;
using Redbox.Core.Services;

namespace Redbox.Infrastructure.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IPriceService, PriceService>();
        }
    }
}
