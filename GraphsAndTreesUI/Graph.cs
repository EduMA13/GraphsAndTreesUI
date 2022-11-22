using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Graph
    {
        public int n;


        public List<String> test1 = new List<string>();
        public string combinedstring;


        public string befes;
        public List<String> test2 = new List<string>();
        public string combinedstring2;


        public int[,] adj = new int[10, 10];

   
        public Graph(int n)
        {
            this.n = n;
           
   

            for (int row = 0; row < n; row++)
                for (int col = 0; col < n; col++)
                    adj[row, col] = 0;
        }

    


        public void displayAdjacencyMatrix()
        {
            StreamWriter sw = new StreamWriter("C:\\Fuentes\\Test.txt");
            for (int i = 0; i < n; ++i)
            {
                sw.WriteLine("");
                for (int j = 0; j < n; ++j)
                {
                    sw.WriteLine("[" + adj[i, j]+"]");

                }

              
            }
            sw.Close();
        }

        public void addEdge(int start, int e)
        {

            adj[start, e] = 1;
            adj[e, start] = 1;
        }

        public void removeEdge(int x, int y)
        {

            adj[y, x] = 0;
            adj[x, y] = 0;

        }

        public void addVertex()
        {
            n++;
            int i;

            for (i = 0; i < n; ++i)
            {
                adj[i, n - 1] = 0;
                adj[n - 1, i] = 0;
                
            }
           
        }

        public void removeVertex(int x)
        {
            if (x > n)
            {
                Console.WriteLine("Vertex is not present!");
                return;
            }
            else
            {
                int i;

                while (x < n)
                {

                    for (i = 0; i < n; ++i)
                    {
                        adj[i, x] = adj[i, x + 1];
                    }

                    for (i = 0; i < n; ++i)
                    {
                        adj[x, i] = adj[x + 1, i];
                    }
                    x++;
                }

                n--;
            }
        }


        public void BFS(int start)
        {

            bool[] visited = new bool[n];
            List<int> q = new List<int>();
            q.Add(start);

            visited[start] = true;

            int vis;

            while (q.Count != 0)
            {
                vis = q[0];

                int x = vis;
                befes = (x.ToString());
                test2.Add(befes);
                Console.Write(vis + "");
                q.Remove(q[0]);


                for (int i = 0; i < n; i++)
                {
                    if (adj[vis, i] == 1 && (!visited[i]))
                    {


                        q.Add(i);

                        visited[i] = true;
                    }
                }
                combinedstring2 = string.Join(",", test2);
            }

        }
        public void DFS(int start)
        {
            bool[] visited = new bool[n];

            
            List<int> q = new List<int>();
            q.Add(start);

            visited[start] = true;
            int vis;
            while (q.Count != 0)
            {
                vis = q[0];

                Console.Write(vis + "");
                q.Remove(q[0]);


                for (int i = 0; i < n; i++)
                {
                    if (adj[vis, i] == 1 && (!visited[i]))
                    {
                        q.Add(i);
                        visited[i] = true;
                    }


                }
            }
        }


        
    }
}


