using System;
using System.Collections.Generic;
using System.IO;

namespace to_TreeAlgorithms
{
    class Program
    {
        static bool IsReady;
        static bool cont = true;
        static void Main(string[] args)
        {
            //load the text from file
            LoadText();

            //creates a list of nodes
            Tree.AddAllNodesToList();
            
            //give the user choices
            while(cont)
            {
                Menu();
            }
        }

        static void Menu()
        {
            int choice = 0;
            string sChoice;
            //get the user's menu choice
            while (true)
            {
                Console.WriteLine("\n1-Find Node By Name\n2-Print Out to File\n3-Exit");
                sChoice = Console.ReadLine();
                try
                {
                    choice = Convert.ToInt32(sChoice);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter a vaild number");
                    continue;
                }
            }
            //based on choice, call function
            switch(choice)
            {
                case 1:
                    GetNode();
                    break;
                case 2:
                    GetPathWay();
                    break;
                case 3:
                    cont = false;
                    break;
            }
        }

        //get the output Pathway
        static void GetPathWay()
        {
            Console.WriteLine("Enter output file pathway: ");
            string s = Console.ReadLine();
            //print out the tree
            Tree.WriteOutlineFile(s);
        }

        //get node(s) to display with their children node values
        static void GetNode()
        {
            Console.WriteLine("Please enter what value you wish to find");
            string s = Console.ReadLine();
            Console.Write("\n");
            //list of node values
            List<string>nodes=Tree.GetNode(s);
            if(nodes.Count>0)
            {
                for(int i =0;i<nodes.Count;i++)
                {
                    //tab the children over
                    Console.Write(nodes[i] + "\t");
                }
            }
            else
            {
                //if value does not exist
                Console.WriteLine("Value not found");
            }
        }

        static void LoadText()
        {
            Console.WriteLine("Enter input file pathway: ");
            string s = Console.ReadLine();
            //read in the data
            string[] lines = File.ReadAllLines(s);

            //amount of white space before first word
            int whiteSpace = 0;
            //string value of each line
            string value = "";

            //for each character value in each line check for tabs and letters
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    //count the amount of tabs
                    if (lines[i][j] == '\t')
                    {
                        whiteSpace++;
                    }
                    //add each word to value
                    if (lines[i][j] != '\t')
                    {
                        value += lines[i][j];
                    }
                }
                //create a new node for each line
                Node node = new Node(value, whiteSpace);
                //if there is no whitespace then create a new root node
                if (whiteSpace == 0)
                {
                    Tree.AddRoot(node);
                    value = "";
                }
                //if there is white space then add a child node
                else if (whiteSpace > 0)
                {
                    Tree.AddNode(node);
                    whiteSpace = 0;
                    value = "";
                }
            }

            IsReady = true;
            Console.WriteLine(IsReady.ToString());
        }
    }
}
