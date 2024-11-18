using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private int _height = 0;
        private int _bf = 0; // balance factor

        public Node(int value, bool isRoot)
        {
            _value = value;
            _isRoot = isRoot;
            _children[0] = null; // left child
            _children[1] = null; // right child
            _height = 1;
            CalculateBalanceFactor();
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

            Console.WriteLine($"Attempting to add {value} to Node {_value}...");
            if (value < _value)
            {
                node = 0;
                word = "left";
            }

            Console.WriteLine($"Attempting to add as {word} child...");
            if (hasChild(node))
            {
                Console.WriteLine($"Node already has a {word} child with value {_children[node]._value}, will pass on to next node...");
                _children[node].AddChild(value);
            }
            else
            {
                _children[node] = new Node(value, false);
                Console.WriteLine($"Successfully added as {word} child...");
            }

            _height = _children[node].getHeight() + 1;

            CalculateBalanceFactor();
            Console.WriteLine($"Updated Balance Factor of node with value {_value} is {_bf}.");

            if (_bf > 1 || _bf < -1)
            {
                Console.WriteLine($"Node {_value} needs rebalancing.");
                // Rotate();
                // determine rotation type
                if (_bf < 0) // left rotation
                {
                    if (hasChild(1) && _children[1].getBalanceFactor() < 0)
                    {
                        Console.WriteLine($"Left Rotation recommended... Rebalancing from node with value {_value}");
                        Console.ReadKey();
                        Rotate(1);
                        Console.WriteLine("Left Rotation completed...");
                        Console.ReadKey();
                    }
                    //else
                    //{
                    //    Console.WriteLine($"Right - Left Rotation recommended... Rebalancing from node with value {_value}");
                    //    Console.ReadKey();
                    //    _children[1].Rotate(0);
                    //    Rotate(1);
                    //    Console.ReadKey();
                    //}
                }
                else if (_bf > 0) // right rotation
                {
                    if (hasChild(0) && _children[0].getBalanceFactor() > 0)
                    {
                        Console.WriteLine($"Right Rotation recommended... Rebalancing from node with value {_value}");
                        Console.ReadKey();
                        Rotate(0);
                        Console.WriteLine("Right Rotation completed...");
                        Console.ReadKey();
                    }
                    //else
                    //{
                    //    Console.WriteLine($"Left - Right Rotation recommended... Rebalancing from node with value {_value}");
                    //    Console.ReadKey();
                    //    _children[0].Rotate(1);
                    //    Rotate(0);
                    //    Console.ReadKey();
                    //}
                }

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

        public int getHeight()
        {
            return _height;
        }

        public int getBalanceFactor()
        {
            return _bf;
        }

        #region Traversal Logics
        public string Prefix()
        {
            string trav = _value + ", ";
            if (hasChild(0))
                trav += _children[0].Prefix();
            if (hasChild(1))
                trav += _children[1].Prefix();

            return trav;
        }

        public string Infix()
        {
            string trav = "";

            if (hasChild(0))
                trav = _children[0].Infix();

            trav += _value + ", ";

            if (hasChild(1))
                trav += _children[1].Infix();

            return trav;
        }

        public string Postfix()
        {
            string trav = "";

            if (hasChild(0))
                trav = _children[0].Postfix();
            if (hasChild(1))
                trav += _children[1].Postfix();
            trav += _value + ", ";

            return trav;
        }

        public List<int> _Prefix(List<int> temp) // RoLR
        {
            temp.Add(_value);

            if (hasChild(0))
                temp = _children[0]._Prefix(temp);
            if (hasChild(1))
                temp = _children[1]._Prefix(temp);

            return temp;
        }

        public List<int> _Infix(List<int> temp) // LRoR
        {
            if (hasChild(0))
                temp = _children[0]._Infix(temp);

            temp.Add(_value);

            if (hasChild(1))
                temp = _children[1]._Infix(temp);

            return temp;
        }

        public List<int> _Postfix(List<int> temp) // LRoR
        {
            if (hasChild(0))
                temp = _children[0]._Postfix(temp);

            if (hasChild(1))
                temp = _children[1]._Postfix(temp);

            temp.Add(_value);

            return temp;
        }
        #endregion

        private void CalculateBalanceFactor()
        {
            int leftBF = 0;
            int rightBF = 0;

            if(hasChild(0))
                leftBF = _children[0].getHeight();

            if (hasChild(1))
                rightBF = _children[1].getHeight();

            _bf = leftBF - rightBF;
        }

        private void Rotate(int child)
        {
            List<int> things = new List<int>();

            things = _children[child]._Prefix(things); // 1,2,3
            things.Insert(0, _value); // 4
            Console.WriteLine($"The current node's value will now change from {_value} to {things[1]}");
            _value = things[1];
            things.RemoveAt(1);

            _children[child] = null;

            foreach(int i in things)
                AddChild(i);
        }

        private void Rotate()
        {
            List<int> things = new List<int>();
            int temp = 0;

            things = _Prefix(things);

            //foreach (int i in things)
            //    Console.Write(i + "," );

            //Console.WriteLine();
            //Console.ReadKey();

            _children[0] = null; // left child
            _children[1] = null; // right child

            temp = things[0];
            things[0] = things[1];
            things[1] = temp;

            //foreach (int i in things)
            //    Console.Write(i + ",");

            //Console.WriteLine();
            //Console.ReadKey();

            Console.WriteLine($"The current node's value will now change from {_value} to {things[0]}");
            _value = things[0];

            things.RemoveAt(0);

            foreach (int i in things)
                AddChild(i);
        }
    }
}
