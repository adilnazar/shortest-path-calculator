using ShortestRouteOptimizer.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShortestRouteOptimizer.Data.Interfaces
{
    public interface IGraphDataLoader
    {
        List<Node> GetNodeGraphData();
    }
}
