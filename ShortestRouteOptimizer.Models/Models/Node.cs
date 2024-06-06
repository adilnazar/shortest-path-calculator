﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestRouteOptimizer.Models.Models
{
    public class Node
    {
        public string Name { get; set; }
        public Dictionary<string, int> Edges { get; set; } = new Dictionary<string, int>();
    }
}
