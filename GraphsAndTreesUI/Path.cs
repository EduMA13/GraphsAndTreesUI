using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    internal class Path
    {
        public class Route
        {
            public List<Node> Nodes { get; set; }

            public int TotalDistance { get; set; }

            public Route()
            {
                Nodes = new List<Node>();
                TotalDistance = 0;

            }

        }

        public class ShortestP
        {
            public List<Node> _graph;
            public int _n;
            private Node _origin { get; set; }

            private List<Route> _Solution { get; set; }



            public string PrintPaths
            {
                get
                {
                    string result = "";

                    foreach (var route in _Solution)
                    {
                        foreach (var node in route.Nodes)
                        {
                            result += node.Vertex + ",";



                        }
                        result += "" + route.TotalDistance + "\n";
                    }
                    return result;

                }
            }
            public ShortestP(List<Node> graph, int n, Node origin)
            {
                _graph = graph;
                _n = n;
                _origin = origin;
            }
            public void Run()
            {
                _Solution = new List<Route>();

                for (int i = 0; i < _n; i++)
                {
                    _Solution.Add(Generate());
                }

                _Solution=_Solution.OrderBy(d=> d.TotalDistance).ToList();

            }

            private Route Generate() {
                var solutions = new Route();

                solutions.Nodes.Add(_origin);
                Node current = _origin;

                for (int i=0; i<_graph.Count-1;i++) 
                {
                    Node next = null;
                    do
                    {
                        next = NextNode(current);
                    } while(solutions.Nodes.Contains(next));

                    solutions.Nodes.Add(next);
                    solutions.TotalDistance += current.Edges.Where(d => d.Node.Vertex == next.Vertex).First().Weight;

                    current= next;
                }

                return solutions;
            
            }


            private Node NextNode(Node current) 
            { 
            int nextNode= new Random().Next(0,_graph.Count-1);

                return current.Edges[nextNode].Node;
            }

        }

    }

}
