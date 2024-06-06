using ShortestRouteOptimizer.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestRouteOptimizer.Service.Interfaces
{
    public interface IPathOptimizerService
    {
        /// <summary>
        /// Get Shortest path for paths nodes provided
        /// </summary>
        /// <param name="fromNodeName"></param>
        /// <param name="toNodeName"></param>
        /// <param name="graphNodes"></param>
        /// <returns></returns>
        ShortestPathData ShortestPath(string fromNodeName, string toNodeName, List<Node> graphNodes);
    }
}
