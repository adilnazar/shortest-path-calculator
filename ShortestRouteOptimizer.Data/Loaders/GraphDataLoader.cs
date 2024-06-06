using ShortestRouteOptimizer.Data.Interfaces;
using ShortestRouteOptimizer.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShortestRouteOptimizer.Data.Loaders
{
    public class GraphDataLoader : IGraphDataLoader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Node> GetNodeGraphData()
        {
            var data = new List<Node>
            {
                new Node
                {
                    Name = "A",
                    Edges = new Dictionary<string, int>
                    {
                        { "B", 4 },
                        { "C", 6 }
                    }
                },
                new Node
                {
                    Name = "B",
                    Edges = new Dictionary<string, int>
                    {
                        { "F", 2 }
                    }
                },
                new Node
                {
                    Name = "C",
                    Edges = new Dictionary<string, int>
                    {
                        { "D", 8 }
                    }
                },
                new Node
                {
                    Name = "D",
                    Edges = new Dictionary<string, int>
                    {
                        { "C", 8 },
                        { "E", 4 },
                        { "G", 1 }
                    }
                },
                new Node
                {
                    Name = "E",
                    Edges = new Dictionary<string, int>
                    {
                        { "B", 2 },
                        { "D", 4 },
                        { "F", 3 },
                        { "I", 8 }
                    }
                },
                new Node
                {
                    Name = "F",
                    Edges = new Dictionary<string, int>
                    {
                        { "B", 2 },
                        { "E", 3 },
                        { "G", 4 },
                        { "H", 6 }
                    }
                },
                new Node
                {
                    Name = "G",
                    Edges = new Dictionary<string, int>
                    {
                        { "D", 1 },
                        { "F", 4 },
                        { "H", 5 },
                        { "I", 5 }
                    }
                },
                new Node
                {
                    Name = "H",
                    Edges = new Dictionary<string, int>
                    {
                        { "F", 6 },
                        { "G", 5 }
                    }
                },
                new Node
                {
                    Name = "I",
                    Edges = new Dictionary<string, int>
                    {
                        { "E", 8 },
                        { "G", 5 }
                    }
                }
            };

            return data;
        }
    }
}
