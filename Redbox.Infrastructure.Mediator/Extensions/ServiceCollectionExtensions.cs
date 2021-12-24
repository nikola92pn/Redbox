using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Redbox.Infrastructure.Mediator.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
