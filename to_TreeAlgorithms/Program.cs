using System;
using System.Collections.Generic;
using System.IO;

namespace to_TreeAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //read in the data
            string[] lines = File.ReadAllLines(@"C:\workspace\unknownTaxonomy.txt");

            //amount of white space before first word
            int whiteSpace = 0;
            //string value of each line
            string value="";

            //for each character value in each line check for tabs and letters
            for(int i=0;i<lines.Length;i++)
            {
                for(int j=0; j < lines[i].Length;j++)
                {
                    //count the amount of tabs
                    if(lines[i][j]=='\t')
                    {
                        whiteSpace++;
                    }
                    //add each word to value
                    if(lines[i][j]!='\t')
                    {
                        value += lines[i][j];
                    }
                }
                //create a new node for each line
                Node node = new Node(value, whiteSpace);
                //if there is no whitespace then create a new root node
                if(whiteSpace==0)
                {
                    Tree.AddRoot(node);
                    value = "";
                }
                //if there is white space then add a child node
                else if(whiteSpace>0)
                {
                    Tree.AddNode(node);
                    whiteSpace = 0;
                    value = "";
                }
            }

            //print out the tree
            Tree.DisplayTree();

            //keep application open
            Console.ReadLine();
        }
    }
}
