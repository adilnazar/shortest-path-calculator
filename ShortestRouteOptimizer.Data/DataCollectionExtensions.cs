using Microsoft.Extensions.DependencyInjection;
using ShortestRouteOptimizer.Data.Interfaces;
using ShortestRouteOptimizer.Data.Loaders;

namespace ShortestRouteOptimizer.Data
{
    public static class DataCollectionExtensions
    {
        public static IServiceCollection AddRouteOptimizerDataCollections(this IServiceCollection services)
        {
            services.AddScoped<IGraphDataLoader, GraphDataLoader>();
            return services;
        }
    }
}
