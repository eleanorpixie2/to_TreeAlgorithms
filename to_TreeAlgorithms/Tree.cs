using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace to_TreeAlgorithms
{
    class Tree
    {
        //creates a list of root nodes
        static List<Node> tree = new List<Node>();

        //the number of roots in the list
        static int root = 0;

        //adds a root node
        public static void AddRoot(Node n)
        {
            tree.Add(n);
            root++;
        }
        //adds child nodes to current root
        public static void AddNode(Node n)
        {
            n.SetNode(tree[root - 1]);
        }

        //display the tree
        public static void WriteOutlineFile()
        {
            for (int i = 0; i < tree.Count; i++)
            {
                DisplayNodes(tree[i]);
            }
        }

        //display each node in the tree
        public static void DisplayNodes(Node n)
        {
            using (StreamWriter file = new StreamWriter(@"C:\workspace\TaxonomyTest.txt", true))
            {

                //add the correct number of tabs for white space
                for (int i = n.whiteSpace; i != 0; i--)
                {
                    file.Write("\t");
                }
                //print out value
               file.WriteLine(n.value);

            }
       
            //display each right most child node
            if (n.right != null)
            {
                DisplayNodes(n.right);
            }
            //display each center child node
            if (n.center != null)
            {
                DisplayNodes(n.center);
            }
            //display each left child node
            if (n.left != null)
            {
                DisplayNodes(n.left);
            }
            //display each leftcenter child node
            if (n.leftCenter != null)
            {
                DisplayNodes(n.leftCenter);
            }
            //display each centerleft child node
            if (n.centerLeft != null)
            {
                DisplayNodes(n.centerLeft);
            }
            //display each centerright child node
            if (n.centerRight != null)
            {
                DisplayNodes(n.centerRight);
            }

        }

    }
}
