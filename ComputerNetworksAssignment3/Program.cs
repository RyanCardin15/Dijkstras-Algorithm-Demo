//Ryan Cardin
//Computer Networks
//Assignment 3
//4/26/20
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerNetworksAssignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> AddedNodes = new List<char>();

            Node A = new Node { Name = 'A', Connection = new List<Link> { new Link { EndNode = 'B', Weight = 4, BeginNode = 'A' }, new Link { EndNode = 'E', Weight = 3, BeginNode = 'A' } } };
            Node B = new Node { Name = 'B', Connection = new List<Link> { new Link { EndNode = 'A', Weight = 4, BeginNode = 'B' }, new Link { EndNode = 'C', Weight = 1, BeginNode = 'B' }, new Link { EndNode = 'D', Weight = 3, BeginNode = 'B' } } };
            Node C = new Node { Name = 'C', Connection = new List<Link> { new Link { EndNode = 'B', Weight = 1, BeginNode = 'C' }, new Link { EndNode = 'D', Weight = 1, BeginNode = 'C' } } };
            Node D = new Node { Name = 'D', Connection = new List<Link> { new Link { EndNode = 'C', Weight = 1, BeginNode = 'D' }, new Link { EndNode = 'B', Weight = 3, BeginNode = 'D' }, new Link { EndNode = 'E', Weight = 5, BeginNode = 'D' } } };
            Node E = new Node { Name = 'E', Connection = new List<Link> { new Link { EndNode = 'A', Weight = 3, BeginNode = 'E' }, new Link { EndNode = 'D', Weight = 5, BeginNode = 'E' } } };

            List<Node> Nodes = new List<Node> { A, B, C, D, E };

            StringBuilder sb = new StringBuilder();

            AddedNodes.Add('A');

            for (int i = 0; i < Nodes.Count; i++)
            {
                Sort(Nodes, sb, AddedNodes);
            }
            Console.WriteLine(sb);
        }

        public static void Sort(List<Node> nodes, StringBuilder sb, List<char> addedNodes)
        {
            var shortestList = from f in nodes
                               where addedNodes.Contains(f.Name)
                               from c in f.Connection
                               where !addedNodes.Contains(c.EndNode)
                               orderby c.Weight
                               select c;

            if (shortestList.Count() > 0)
            {
                var shortestNode = shortestList.First();
                Console.WriteLine($"From {shortestNode.BeginNode} -----{shortestNode.Weight}----> {shortestNode.EndNode}");
                addedNodes.Add(shortestNode.EndNode);
            }
        }
    }

    class Node
    {
        public char Name { get; set; }
        public List<Link> Connection { get; set; }

    }

    class Link
    {
        public char EndNode { get; set; }
        public int Weight { get; set; }
        public char BeginNode { get; set; }
    }
}
