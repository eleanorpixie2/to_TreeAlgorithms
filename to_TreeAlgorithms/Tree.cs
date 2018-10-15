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

        //contains all node values
        static List<Node> nodes = new List<Node>();

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
        public static void WriteOutlineFile(string path)
        {
            for (int i = 0; i < tree.Count; i++)
            {
                DisplayNodes(tree[i],path);
            }
        }

        //display each node in the tree
        public static void DisplayNodes(Node n,string s)
        {
            using (StreamWriter file = new StreamWriter(s, true))
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
                DisplayNodes(n.right,s);
            }
            //display each center child node
            if (n.center != null)
            {
                DisplayNodes(n.center,s);
            }
            //display each left child node
            if (n.left != null)
            {
                DisplayNodes(n.left,s);
            }
            //display each leftcenter child node
            if (n.leftCenter != null)
            {
                DisplayNodes(n.leftCenter,s);
            }
            //display each centerleft child node
            if (n.centerLeft != null)
            {
                DisplayNodes(n.centerLeft,s);
            }
            //display each centerright child node
            if (n.centerRight != null)
            {
                DisplayNodes(n.centerRight,s);
            }

        }

        public static List<string> GetNode(string s)
        {
            //list of nodes that match the string value
            List<Node> n = new List<Node>();
            //list of string values for each node that meets the string value
            List<string> values = new List<string>();
            for(int i=0;i<nodes.Count;i++)
            {
                if(nodes[i].value.Contains(s))
                {
                    n.Add(nodes[i]);
                }
            }
            if (n != null)
            {
                for (int i = 0; i < n.Count; i++)
                {
                    //add node
                    values.Add(n[i].value);
                    //display right child
                    if (n[i].right != null)
                    {
                        values.Add("\n\t" + n[i].right.value);
                    }
                    //display each center child node
                    if (n[i].center != null)
                    {
                        values.Add("\n\t" + n[i].center.value);
                    }
                    //display each left child node
                    if (n[i].left != null)
                    {
                        values.Add("\n\t" + n[i].left.value);
                    }
                    //display each leftcenter child node
                    if (n[i].leftCenter != null)
                    {
                        values.Add("\n\t" + n[i].leftCenter.value);
                    }
                    //display each centerleft child node
                    if (n[i].centerLeft != null)
                    {
                        values.Add("\n\t" + n[i].centerLeft.value);
                    }
                    //display each centerright child node
                    if (n[i].centerRight != null)
                    {
                        values.Add("\n\t" + n[i].centerRight.value);
                    }
                }
            }
            //return string list
            return values;
        }

        //add each node to a list
        public static void AddAllNodesToList()
        {
            for (int i = 0; i < tree.Count; i++)
            {
                GetNodeValues (tree[i]);
            }
        }

        static void GetNodeValues(Node n)
        {
            nodes.Add(n);
            //display each right most child node
            if (n.right != null)
            {
                GetNodeValues(n.right);
            }
            //display each center child node
            if (n.center != null)
            {
                GetNodeValues(n.center);
            }
            //display each left child node
            if (n.left != null)
            {
                GetNodeValues(n.left);
            }
            //display each leftcenter child node
            if (n.leftCenter != null)
            {
                GetNodeValues(n.leftCenter);
            }
            //display each centerleft child node
            if (n.centerLeft != null)
            {
                GetNodeValues(n.centerLeft);
            }
            //display each centerright child node
            if (n.centerRight != null)
            {
                GetNodeValues(n.centerRight);
            }
        }

    }
}
