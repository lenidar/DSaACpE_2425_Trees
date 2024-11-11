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
            int[] ints = new int[] {42, 22, 92, 45, 18,  6, 40, 54, 97, 78 };
            Tree t1 = new Tree(50);
            for(int x = 0; x < ints.Length; x++) 
                t1.AddValueToTree(ints[x]);

            Console.WriteLine($"\nTree has {t1.getNodeCount()} nodes in total.");

            Console.WriteLine("Prefix tree traversal:\n" + t1.PreFixTraverse());

            Console.WriteLine("Infix tree traversal:\n" + t1.InFixTraverse());

            Console.WriteLine("Postfix tree traversal:\n" + t1.PostFixTraverse());

            Console.ReadKey();
        }
    }
}
