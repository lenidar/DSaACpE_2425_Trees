using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSaACpE_2425_Trees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] ints = new int[] {50, 42, 22, 92, 45, 18,  6, 40, 54, 97, 78 };
            //int[] ints = new int[] {50, 92,45,54,97,78 };
            int[] ints = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // left rotation test
            //int[] ints = new int[] {10,9,8,7,6,5,4,3,2,1 }; // right rotation test
            //int[] ints = new int[] { 3,1,2}; // left right rotation test
            //int[] ints = new int[] { 1,3,2}; // right left rotation test
            Tree t1 = new Tree(ints[0]);
            for(int x = 1; x < ints.Length; x++) 
                t1.AddValueToTree(ints[x]);

            Console.WriteLine($"\nTree has {t1.getNodeCount()} nodes in total.");

            //Console.WriteLine("Prefix tree traversal:\n" + t1.PreFixTraverse());
            Console.WriteLine("Prefix tree traversal:\n" + t1.Prefix());

            //Console.WriteLine("Infix tree traversal:\n" + t1.InFixTraverse());
            Console.WriteLine("Infix tree traversal:\n" + t1.Infix());

            //Console.WriteLine("Postfix tree traversal:\n" + t1.PostFixTraverse());
            Console.WriteLine("Postfix tree traversal:\n" + t1.Postfix());

            //Console.WriteLine("Postfix tree traversal2:\n" + t1.PostFix());

            Console.ReadKey();
        }
    }
}
