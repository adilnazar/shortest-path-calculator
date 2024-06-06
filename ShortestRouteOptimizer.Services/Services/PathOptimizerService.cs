using ShortestRouteOptimizer.Services.Model;
using ShortestRouteOptimizer.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestRouteOptimizer.Services.Services
{
    public class PathOptimizerService : IPathOptimizerService
    {
        public ShortestPathData ShortestPath(string fromNodeName, string toNodeName, List<Node> graphNodes)
        {
            var distances = new Dictionary<string, int>();
            var previousNodes = new Dictionary<string, string>();
            var nodes = new List<string>();

            foreach (var node in graphNodes)
            {
                if (node.Name == fromNodeName)
                {
                    distances[node.Name] = 0;
                }
                else
                {
                    distances[node.Name] = int.MaxValue;
                }

                nodes.Add(node.Name);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);
                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == toNodeName)
                {
                    var path = new List<string>();
                    while (previousNodes.ContainsKey(smallest))
                    {
                        path.Insert(0, smallest);
                        smallest = previousNodes[smallest];
                    }
                    path.Insert(0, fromNodeName);

                    return new ShortestPathData
                    {
                        NodeNames = path,
                        Distance = distances[toNodeName]
                    };
                }

                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in graphNodes.First(x => x.Name == smallest).Edges)
                {
                    var alt = distances[smallest] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previousNodes[neighbor.Key] = smallest;
                    }
                }
            }

            return null;
        }
    }
}
