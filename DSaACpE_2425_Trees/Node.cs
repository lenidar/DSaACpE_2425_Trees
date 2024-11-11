using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSaACpE_2425_Trees
{
    internal class Node
    {
        private int _value = 0;
        /// <summary>
        /// Node type 0 for root, -1 for left, 1 for right
        /// </summary>
        private bool _isRoot = false; 
        private Node[] _children = new Node[2];

        public Node(int value, bool isRoot)
        {
            _value = value;
            _isRoot = isRoot;
            _children[0] = null; // left child
            _children[1] = null; // right child
        }

        public int getValue() { return _value; }

        public bool hasChild()
        {
            if (_children[0] == null &&  _children[1] == null)
                return false;
            return true;
        }

        /// <summary>
        /// this will return true or false depending on the x value
        /// x is 0 when you are asking about left child
        /// x is 1 when you are asking about right child
        /// </summary>
        /// <param name="x">index of child</param>
        /// <returns></returns>
        public bool hasChild(int x)
        {
            if (_children[x] == null)
                return false;
            return true;
        }

        public void AddChild(int value)
        {
            int node = 1;
            string word = "right";

            Console.WriteLine($"Attempting to add {value} to Node...");
            if (value < _value)
            {
                node = 0;
                word = "left";
            }
            //else
            //{
            //    node = 1;
            //    word = "right";
            //    Console.WriteLine($"Attempting to add as right child...");
            //    if (hasChild(1))
            //    {
            //        Console.WriteLine($"Node already has a right child, will pass on to next node...");
            //        _children[1].AddChild(value);
            //    }
            //    else
            //    {
            //        _children[1] = new Node(value, false);
            //        Console.WriteLine($"Successfully added as right child...");
            //    }
            //}

            Console.WriteLine($"Attempting to add as {word} child...");
            if (hasChild(node))
            {
                Console.WriteLine($"Node already has a {word} child, will pass on to next node...");
                _children[node].AddChild(value);
            }
            else
            {
                _children[node] = new Node(value, false);
                Console.WriteLine($"Successfully added as {word} child...");
            }
        }

        public int getCount()
        {
            int cnt = 1;

            if(hasChild(0))
                cnt += _children[0].getCount();
            if (hasChild(1))
                cnt += _children[1].getCount();

            return cnt;
        }

        public string Prefix()
        {
            string trav = _value + ", ";
            if(hasChild(0))
                trav += _children[0].Prefix();
            if (hasChild(1))
                trav += _children[1].Prefix();

            return trav;
        }

        public string Infix()
        {
            string trav = "";

            if(hasChild(0))
                trav = _children[0].Infix();

            trav += _value + ", ";

            if (hasChild(1))
                trav+= _children[1].Infix();

            return trav; 
        }

        public string Postfix()
        {
            string trav = "";

            if(hasChild(0))
                trav = _children[0].Postfix();
            if(hasChild(1))
                trav += _children[1].Postfix();
            trav += _value + ", ";

            return trav;
        }
    }
}
