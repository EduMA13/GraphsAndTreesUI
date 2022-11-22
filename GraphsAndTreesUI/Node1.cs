using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    internal class Node
    {
    
            public string Vertex { get; set; }

            public List<Edge> Edges { get; set; }

        

        public struct Edge
        {

            public Node Node { get; set; }

            public int Weight { get; set; }

        }

        public Node() { 
        Edges =  new List<Edge>();
        }
    }
}
