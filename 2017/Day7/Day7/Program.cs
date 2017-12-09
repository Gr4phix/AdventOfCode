using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    class Program
    {
        public class Node
        {
            public string Name { get; set; }
            public int Weight { get; }
            public List<string> Children { get; }

            public Node(string name, int weight)
            {
                this.Name = name;
                this.Weight = weight;
            }

            public Node(string name, int weight, IEnumerable<string> children)
            {
                this.Name = name;
                this.Weight = weight;
                this.Children = new List<string>();

                foreach (string child in children)
                {
                    Children.Add(child);
                }
            }
        }

        static void Main(string[] args)
        {
            List<String> input = File.ReadLines(@"input.txt").ToList();
            Dictionary<string, int> progs = new Dictionary<string, int>();
            List<Node> nodes = new List<Node>();

            foreach (String inputString in input)
            {
                char[] inputChar = inputString.ToCharArray();
                string helpN = "";
                for (int i = 0; i < Array.IndexOf(inputChar, ' '); i++)
                    helpN += inputChar[i];

                string helpW = "";
                for (int i = Array.IndexOf(inputChar, '(') + 1; i < Array.IndexOf(inputChar, ')'); i++)
                    helpW += inputChar[i];

                progs.Add(helpN, Convert.ToInt32(helpW));
               
                if (inputChar.Count() > Array.IndexOf(inputChar, ')') +1 )
                {
                    int childsCount = 0;
                    string childString = "";
                    for (int i = Array.IndexOf(inputChar, ')') + 5; i < inputChar.Count(); i++)
                    {
                        if (inputChar[i] == ',') childsCount++;
                        childString += inputChar[i];
                    }
                    char[] childChar = childString.ToCharArray();
                    List<string> help = new List<string>();

                    string helpp = "";

                    for (int l = 0; l < childChar.Length; l++)
                    {
                        if (childChar[l] != ' ')
                            if (childChar[l] == ',')
                            {
                                help.Add(helpp);
                                helpp = "";
                            }
                            else
                            {
                                helpp += childChar[l];
                            }
                    }
                    help.Add(helpp);

                    nodes.Add(new Node(helpN, Convert.ToInt32(helpW), help.ToList()));
                }
                else
                    nodes.Add(new Node(helpN, Convert.ToInt32(helpW)));
            }

            List<string> helpNames = new List<string>();
            foreach (Node node in nodes)
                helpNames.Add(node.Name);

            foreach (Node node in nodes)
                try
                {
                    foreach (string child in node.Children)
                    {
                        helpNames.Remove(child);
                    }
                }
                catch { }

            Console.Write("#1: {0} ", String.Join(", ", helpNames));                 
            Console.ReadKey();
        }
    }
}
