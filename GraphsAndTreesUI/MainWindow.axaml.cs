using Avalonia.Controls;
using Avalonia.Interactivity;
using BinaryTrees;
using ShortestPath;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GraphsAndTreesUI
{
    public partial class MainWindow : Window
    {
        BinaryTrees.BinaryTree binarytree = new BinaryTrees.BinaryTree();
        Graphs.Graph graph = new Graphs.Graph(4);

        ShortestPath.Node NodeA = new ShortestPath.Node();

        ShortestPath.Node NodeB = new ShortestPath.Node();
      
        ShortestPath.Node NodeC = new ShortestPath.Node();
     

        ShortestPath.Node NodeD = new ShortestPath.Node();
      
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button1_Tree(object sender, RoutedEventArgs e) { 
        
            U1.IsVisible = false;
            TreeButton.IsVisible=false;
            GraphButton.IsVisible=false;
            ShortestPath.IsVisible = false;
            U2.IsVisible=true;
        }
        public void Button2_Graph(object sender, RoutedEventArgs e)
        {

            U1.IsVisible = false;
            TreeButton.IsVisible = false;
            GraphButton.IsVisible = false;
            ShortestPath.IsVisible = false;
            U3.IsVisible = true;
        }

        public void Button3_Shortest(object sender, RoutedEventArgs e) {
            U1.IsVisible = false;
            TreeButton.IsVisible = false;
            GraphButton.IsVisible = false;
            ShortestPath.IsVisible = false;
            U4.IsVisible = true;

        }
        public void addNode(object sender, RoutedEventArgs e) {
            binarytree.Add(7);
            binarytree.Add(3);
            binarytree.Add(12);
            binarytree.Add(1);
            binarytree.Add(6);
            binarytree.Add(9);
            binarytree.Add(13);
            binarytree.Add(0);
            binarytree.Add(2);
            binarytree.Add(4);
            binarytree.Add(8);
            binarytree.Add(11);
            binarytree.Add(15);
            binarytree.Add(5);
            binarytree.Add(10);
            binarytree.Add(14);
        }

        public void backTree(object sender, RoutedEventArgs e) { 
        
            U2.IsVisible = true;
            RES.IsVisible = false;
            PT.IsVisible = false;
        }
        public void backTree2(object sender, RoutedEventArgs e) {
            U1.IsVisible = true;
            TreeButton.IsVisible = true;
            GraphButton.IsVisible = true;
            ShortestPath.IsVisible = true;
            U2.IsVisible = false;

        }
        public void backShort(object sender, RoutedEventArgs e) {
            U4.IsVisible = false;
            U1.IsVisible=true;
            TreeButton.IsVisible = true;
            GraphButton.IsVisible = true;
            ShortestPath.IsVisible = true;

        }
        public void removeNode(object sender, RoutedEventArgs e) {
            binarytree.Remove(int.Parse(remNodeNum.Text));
        }

        public void orders(object sender, RoutedEventArgs e) {
            RES.IsVisible = true;
            PT.IsVisible = true;
            U2.IsVisible = false;
            Stree.IsVisible = true;
            BackGraph.IsVisible = false;

            binarytree.TraversePreOrder(binarytree.Root);
            PTR2.Text = "PreOrder Traversal" + "\n" + binarytree.combinedstring;
        
            binarytree.TraverseInOrder(binarytree.Root);
            PTR3.Text ="InOrder Traversal"+ "\n" + binarytree.combinedstring2;
    

            Console.WriteLine("PostOrder:");
            binarytree.TraversePostOrder(binarytree.Root);
            PTR4.Text = "PostOrder Traversal" + "\n" + binarytree.combinedstring3;
            Console.WriteLine();

        }

        public void openImage(object sender, RoutedEventArgs e) {
            binarytree.graficar();
        }
        public void addEdges1(object sender, RoutedEventArgs e) {
            graph.addEdge(4, 1);
            graph.addEdge(4, 3);
        }
        public void generateMatrix(object sender, RoutedEventArgs e) {
            graph.addEdge(0, 1);
            graph.addEdge(0, 2);
            graph.addEdge(1, 2);
            graph.addEdge(2, 3);
        }

        public void deleteEdges1(object sender, RoutedEventArgs e) {
            graph.removeEdge(4, 3);
        
        }

        public void addVertex1(object sender, RoutedEventArgs e) {

            graph.addVertex();
        }

        public void deleteVertex1(object sender, RoutedEventArgs e) {
            graph.removeVertex(1);
        }

        public void bfs1(object sender, RoutedEventArgs e) {
            RES.IsVisible = true;
            PT.IsVisible = true;
            U3.IsVisible = false;
            BackTree.IsVisible = false;
            Stree.IsVisible = false;
            BackGraph.IsVisible = true;
            graph.BFS(1);
            PTR2.Text = " BFS" + "\n" + graph.combinedstring2;
            graph.DFS(1);
            PTR3.Text = " DFS" + "\n" + graph.combinedstring2;

            PTR4.IsVisible = false;
        }
        public void backGraph(object sender, RoutedEventArgs e) {

            U3.IsVisible = true;
            RES.IsVisible = false;
            PT.IsVisible = false;
            BackGraph.IsVisible = false;
        }
        public void printMatrix(object sender, RoutedEventArgs e) {
            graph.displayAdjacencyMatrix();

        }

        public void generateShort(object sender, RoutedEventArgs e) {
            StreamWriter sw = new StreamWriter("C:\\Fuentes\\Shortest.txt");

            NodeA.Vertex = "A";

            NodeB.Vertex = "B";

            NodeC.Vertex = "C";

            NodeD.Vertex = "D";



            //A to B and C
            NodeA.Edges.Add(new ShortestPath.Node.Edge() { Node = NodeB, Weight = 5 });
            NodeA.Edges.Add(new ShortestPath.Node.Edge() { Node = NodeC, Weight = 10 });
            NodeA.Edges.Add(new ShortestPath.Node.Edge() { Node = NodeD, Weight = 0 });
            //B to A, C and D
            NodeB.Edges.Add(new ShortestPath.Node.Edge() { Node = NodeA, Weight = 5 });
            NodeB.Edges.Add(new ShortestPath.Node.Edge() { Node = NodeC, Weight = 10 });
            NodeB.Edges.Add(new ShortestPath.Node.Edge() { Node = NodeD, Weight = 7 });

            //C to A, B and D
            NodeC.Edges.Add(new ShortestPath.Node.Edge() { Node = NodeA, Weight = 10 });
            NodeC.Edges.Add(new ShortestPath.Node.Edge() { Node = NodeB, Weight = 6 });
            NodeC.Edges.Add(new ShortestPath.Node.Edge() { Node = NodeD, Weight = 14 });

            //D to B,A and C
            NodeD.Edges.Add(new ShortestPath.Node.Edge() { Node = NodeA, Weight = 0 });
            NodeD.Edges.Add(new ShortestPath.Node.Edge() { Node = NodeB, Weight = 7 });
            NodeD.Edges.Add(new ShortestPath.Node.Edge() { Node = NodeC, Weight = 14 });

            List<ShortestPath.Node> graph = new List<ShortestPath.Node> { NodeA, NodeB, NodeC, NodeD };
            var algorithm = new ShortestPath.Path.ShortestP(graph, 4, NodeA);
            algorithm.Run();
            sw.WriteLine(algorithm.PrintPaths);

            sw.Close();
        }
    }
}