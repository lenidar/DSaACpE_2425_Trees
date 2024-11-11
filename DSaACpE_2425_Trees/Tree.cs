using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSaACpE_2425_Trees
{
    internal class Tree
    {
        private Node root = null;

        public Tree(int value) 
        {
            root = new Node(value, true);
            Console.WriteLine($"Successfully created tree with root node {value}");
        }

        public void AddValueToTree(int value)
        {
            Console.ReadKey();
            Console.WriteLine();
            root.AddChild(value);
        }

        public int getNodeCount()
        {
            return root.getCount();
        }

        public string PreFixTraverse()
        {
            return root.Prefix();
        }

        public string InFixTraverse()
        {
            return root.Infix();
        }

        public string PostFixTraverse()
        {
            return root.Postfix();
        }
    }
}
