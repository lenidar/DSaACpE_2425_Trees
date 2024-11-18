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
            Console.WriteLine($"Successfully created tree with root node {value}. Current Tree height is {root.getHeight()}. Current Balance Factor is {root.getBalanceFactor()}.");
        }

        public void AddValueToTree(int value)
        {
            Console.ReadKey();
            Console.WriteLine();
            root.AddChild(value);
            Console.WriteLine($"Current height of tree is {root.getHeight()}");
        }

        public int getNodeCount()
        {
            return root.getCount();
        }

        public string PreFixTraverse()
        {
            return root.Prefix();
        }

        public string Prefix()
        {
            List<int> temp = new List<int>();
            string thing = "";

            temp = root._Prefix(temp);

            foreach(int t in temp)
            {
                thing += t + ", ";
            }

            return thing;
        }

        public string InFixTraverse()
        {
            return root.Infix();
        }

        public string Infix()
        {
            List<int> temp = new List<int>();
            string thing = "";

            temp = root._Infix(temp);

            foreach (int t in temp)
            {
                thing += t + ", ";
            }

            return thing;
        }

        public string PostFixTraverse()
        {
            return root.Postfix();
        }
        
        public string Postfix()
        {
            List<int> temp = new List<int>();
            string thing = "";

            temp = root._Postfix(temp);

            foreach (int t in temp)
            {
                thing += t + ", ";
            }

            return thing;
        }
    }
}
