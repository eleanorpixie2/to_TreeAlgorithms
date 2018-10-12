using System;
using System.Collections.Generic;
using System.Text;

namespace to_TreeAlgorithms
{
    class Node
    {
        //value of the node
        public string value;
        //child objects of nodes
        public Node right;
        public Node left;
        public Node center;
        public Node centerLeft;
        public Node centerRight;
        public Node leftCenter;
        //parent node of each node
        private Node parent;
        //amount of whitepace in front of each line
        public int whiteSpace;

        //constructor, creates default node
        public Node(string val,int space)
        {
            value = val;
            right = null;
            left = null;
            center = null;
            whiteSpace = space;
        }

        //adds a node to the tree
        public void SetNode(Node n)
        {
            //if the node has less white space then add to left of parent
            if (this.whiteSpace < n.whiteSpace)
            {
                if (n.left == null)
                {
                    n.left = this;
                    this.parent=n;
                }
                //call recursively until null is found
                else
                {
                    SetNode(n.left);
                }
            }
            //if the amount of white space is greater then add to right of parent
            else if (this.whiteSpace > n.whiteSpace)
            {
                if (n.right == null)
                {
                    n.right = this;
                    this.parent = n;
                }
                //if all three are filled then go to left most object and check from there for null
                else if (n.left != null && n.right != null && n.center != null)
                {
                    SetNode(n.left);
                }
                //call recursively until null is found
                else
                {
                    SetNode(n.right);
                }
            }
            //if whitespace is equal then add as child of node
            else if(this.whiteSpace==n.whiteSpace)
            {
                //the right most child
                if(n.parent.right==null)
                {
                    n.parent.right = this;
                    this.parent = n.parent;
                }
                //the center child
                else if(n.parent.center == null)
                {
                    n.parent.center = this;
                    this.parent = n.parent;
                }
                //the left most child
                else if (n.parent.left == null)
                {
                    n.parent.left = this;
                    this.parent = n.parent;
                }
                //the child between left and center left
                else if (n.parent.leftCenter == null)
                {
                    n.parent.leftCenter = this;
                    this.parent = n.parent;
                }
                //child between left center and center
                else if (n.parent.centerLeft == null)
                {
                    n.parent.centerLeft = this;
                    this.parent = n.parent;
                }
                //child between center and right most
                else if (n.parent.centerRight == null)
                {
                    n.parent.centerRight = this;
                    this.parent = n.parent;
                }
            }
        }

    }
}
