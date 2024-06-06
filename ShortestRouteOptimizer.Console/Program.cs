using Microsoft.Extensions.DependencyInjection;
using ShortestRouteOptimizer.Data.Interfaces;
using ShortestRouteOptimizer.Data.Loaders;
using ShortestRouteOptimizer.Service.Interfaces;
using ShortestRouteOptimizer.Service.Services;

try
{
    var servicePrrovider = new ServiceCollection()
    .AddScoped<IPathOptimizerService, PathOptimizerService>()
    .AddScoped<IGraphDataLoader, GraphDataLoader>()
    .BuildServiceProvider();

    var graphLoader = servicePrrovider.GetRequiredService<IGraphDataLoader>();
    var pathOptimizerService = servicePrrovider.GetRequiredService<IPathOptimizerService>();

    var nodes = graphLoader.GetNodeGraphData();

    var validNodes = new HashSet<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I" };

    string fromNode, toNode;

    while (true)
    {
        Console.Write("Enter the From node: ");
        fromNode = Console.ReadLine().ToUpper();

        if (!validNodes.Contains(fromNode))
        {
            Console.WriteLine($"Invalid From node. Please enter a node from {string.Join(", ", validNodes)}.");
        }
        else
        {
            break;
        }
    }

    while (true)
    {
        Console.Write("Enter the To node: ");
        toNode = Console.ReadLine().ToUpper();

        if (!validNodes.Contains(toNode))
        {
            Console.WriteLine($"Invalid to node. Please enter a node from {string.Join(", ", validNodes)}.");
        }
        else
        {
            break;
        }
    }

    var shortestPath = pathOptimizerService.ShortestPath(fromNode, toNode, nodes);

    Console.WriteLine($"Shortest path is {string.Join(", ", shortestPath.NodeNames)}");
    Console.WriteLine($"Distance is {shortestPath.Distance}");
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred while processing your request.");
    Console.WriteLine($"Error details: {ex.Message}");
}