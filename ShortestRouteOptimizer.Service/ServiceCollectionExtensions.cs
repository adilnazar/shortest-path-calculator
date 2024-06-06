using Microsoft.Extensions.DependencyInjection;
using ShortestRouteOptimizer.Service.Interfaces;
using ShortestRouteOptimizer.Service.Services;

namespace ShortestRouteOptimizer.Service
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRouteOptimizerServiceCollections(this IServiceCollection services)
        {
            services.AddScoped<IPathOptimizerService, PathOptimizerService>();
            return services;
        }
    }
}
