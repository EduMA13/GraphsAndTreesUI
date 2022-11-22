using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Avalonia.FreeDesktop.DBusIme;
using System.Drawing;

namespace BinaryTrees
{
    class BinaryTree
    {
        public Node Root { get; set; }
        private string code_graph = "";

        public string PRO;
        public string combinedstring;
        public List<String> test1 = new List<string>();

        public string INO;
        public string combinedstring2;
        public List <String> test2= new List<string> ();

        public string POR;
        public string combinedstring3;
        public List <String> test3= new List<string> ();

        public bool Add(int value)
        {
            Node before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value < after.Data)
                    after = after.LeftNode;
                else if (value > after.Data)
                    after = after.RightNode;
                else
                {

                    return false;
                }
            }

            Node newNode = new Node();
            newNode.Data = value;

            if (this.Root == null)
                this.Root = newNode;
            else
            {
                if (value < before.Data)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }

        private Node Remove(Node parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key > parent.Data)
                parent.RightNode = Remove(parent.RightNode, key);


            else
            {

                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;


                parent.Data = MinValue(parent.RightNode);


                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        private int MinValue(Node node)
        {
            int minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }

        private Node Find(int value, Node parent)
        {
            if (parent != null)
            {
                if (value == parent.Data) return parent;
                if (value < parent.Data)
                    return Find(value, parent.LeftNode);
                else
                    return Find(value, parent.RightNode);
            }

            return null;
        }
        public void Remove(int value)
        {
            this.Root = Remove(this.Root, value);
        }
        public void TraversePreOrder(Node parent)
        {
            if (parent != null)
            {
                int x = parent.Data;
                PRO = (x.ToString());
                test1.Add(PRO);
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
            combinedstring = string.Join(",", test1);
        }

        public void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.Write(parent.Data + " ");
                int x = parent.Data;
                INO = (x.ToString());
                test2.Add(INO);
                TraverseInOrder(parent.RightNode);
            }
            combinedstring2 = string.Join(",", test2);
        }

        public void TraversePostOrder(Node parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Console.Write(parent.Data + " ");
                int x= parent.Data;
                POR = (x.ToString());
                test3.Add(POR);
            }
            combinedstring3 = string.Join(",", test3);
        }

        public void graficar()
        {
            TextWriter text;
            text = new StreamWriter("C:\\Fuentes\\abbT.txt");
            string escribir;
            escribir = obtenernodos();
            text.WriteLine(escribir);
            text.Close();

            Generate_Graph("abbT.txt", "C:/Fuentes");
        }

        public string obtenernodos()
        {
            code_graph += "digraph{";
            code_graph += "\n";
            code_graph += "\n";

            code_graph += "subgraph cluster_1{ ";
            code_graph += "\n";
            code_graph += "label = \"Binary Tree:\"; ";
            code_graph += "\n";

            agregarmasnodos(Root);

            code_graph += "\n";
            code_graph += "}";
            code_graph += "\n";
            code_graph += "\n";
            code_graph += "}";

            return code_graph;
        }

        public void agregarmasnodos(Node root)
        {
            if (root != null)
            {
                code_graph += "\n";
                if (root.LeftNode != null)
                {
                    agregarmasnodos(root.LeftNode);
                    code_graph += (root.Data.ToString() + "->" + root.LeftNode.Data.ToString());
                    code_graph += "\n";
                }
                if (root.RightNode != null)
                {
                    agregarmasnodos(root.RightNode);
                    code_graph += (root.Data.ToString() + "->" + root.RightNode.Data.ToString());
                    code_graph += "\n";
                }
            }
        }

        public static void Generate_Graph(string fileName, string path)
        {
            try
            {
                var command = string.Format("dot -Tjpg {0} -o {1}", Path.Combine(path, fileName), Path.Combine(path, fileName.Replace(".txt", ".jpg")));
                var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/C " + command);
                var proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception x)
            {
                Console.WriteLine(x.ToString());
            }
        }
    }
}