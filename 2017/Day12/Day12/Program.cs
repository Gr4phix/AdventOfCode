using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> input = File.ReadLines(@"input.txt").ToList();
            Dictionary<int, List<int>> pipes = new Dictionary<int, List<int>>();

            foreach (string line in input)
            {
                char[] inputChar = line.ToCharArray();
                string helpFirstDigit = "";
                for (int i = 0; i < Array.IndexOf(inputChar, ' '); i++)
                    helpFirstDigit += inputChar[i];
                int pipeFrom = Convert.ToInt32(helpFirstDigit);

                int pipesToCount = 0;
                string pipesString = "";
                for (int i = Array.IndexOf(inputChar, '>') + 1; i < inputChar.Count(); i++)
                {
                    if (inputChar[i] == ',')
                        pipesToCount++;
                    pipesString += inputChar[i];
                }

                char[] pipesToChar = pipesString.ToCharArray();
                List<int> pipesToList = new List<int>();

                string helpp = "";
                for (int i = 0; i < pipesToChar.Length; i++)
                {
                    if (pipesToChar[i] != ' ')
                        if (pipesToChar[i] == ',')
                        {
                            pipesToList.Add(Convert.ToInt32(helpp));
                            helpp = "";
                        }
                        else
                            helpp += pipesToChar[i];
                }
                pipesToList.Add(Convert.ToInt32(helpp));

                pipes.Add(pipeFrom, pipesToList);
            }

            List<int> programmsID0 = new List<int>();

            foreach (KeyValuePair<int, List<int>> entry in pipes)
            {
                if(entry.Value.Contains(0))
                {
                    programmsID0.Add(entry.Key);
                    foreach (int prog in entry.Value)
                    {
                        programmsID0.Add(prog);
                    }
                }
            }
            List<int> help = new List<int>();
            for (int i = 0; i < 50; i++)
            {
                foreach (int value in programmsID0)
                {
                    List<int> toPipes;
                    pipes.TryGetValue(value, out toPipes);

                    foreach (int pipe in toPipes)
                    {
                        //programmsID0.Add(pipe);
                        help.Add(pipe);
                    }
                }
                foreach (int pipe in help)
                    programmsID0.Add(pipe);
            }


            List<int> programmsID0NoDups = programmsID0.Distinct().ToList();

            Console.Write("#1: {0}", programmsID0NoDups.Count +1);
            //Console.Write("{0}", String.Join(";", pipes.Select(x => x.Key + "=" + String.Join(',', x.Value.ToString())).ToArray()));
            Console.ReadKey();
        }
    }
}
