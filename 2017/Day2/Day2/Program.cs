using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> summands = new List<int>();
            String[] lines = File.ReadAllLines(@"code.txt");

            foreach (string line in lines)
            {
                List<int> lineThings = new List<int>();
                char[] charLine = line.ToCharArray();
                for (int i = 0; i < charLine.Length; i++)
                {
                    if (charLine[i] != ' ')
                        lineThings.Add((int)charLine[i] - '0');
                }
                lineThings.Add(-39);

                List<int> help = new List<int>();
                String help2 = "";
                for (int i = 0; i < lineThings.Count; i++)
                {
                    if (lineThings[i] != -39)
                    {
                        help2 += lineThings[i];
                    }
                    else
                    {
                        help.Add(Convert.ToInt32(help2));
                        help2 = "";
                    }
                }
                summands.Add(help.Max() - help.Min());
            }

            Console.Write("The Anwser for Puzzle 1 is: {0} ", summands.Sum());

            summands.Clear();
            String[] lines2 = File.ReadAllLines(@"code2.txt");
            foreach (string line in lines2)
            {
                List<int> lineThings = new List<int>();
                char[] charLine = line.ToCharArray();
                for (int i = 0; i < charLine.Length; i++)
                {
                    if (charLine[i] != ' ')
                        lineThings.Add((int)charLine[i] - '0');
                }
                lineThings.Add(-39);

                List<int> help = new List<int>();
                String help2 = "";
                for (int i = 0; i < lineThings.Count; i++)
                {
                    if (lineThings[i] != -39)
                    {
                        help2 += lineThings[i];
                    }
                    else
                    {
                        help.Add(Convert.ToInt32(help2));
                        help2 = "";
                    }
                }

                foreach (int number1 in help)
                {
                    for (int i = 0; i < help.Count; i++)
                        if (number1 != help[i])
                            if (number1 % help[i] == 0)
                                summands.Add(number1 / help[i]);
                }
            }
            Console.Write("\n\nThe Anwser for Puzzle 2 is: {0} ", summands.Sum());

            Console.ReadKey();
        }
    }
}
