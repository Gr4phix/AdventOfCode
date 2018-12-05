using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines(Directory.GetCurrentDirectory() + @"/input").ToList()[0];
            Console.WriteLine(input.Length);
            var inputPartOne = ReactingPolymer(input);

            Console.WriteLine($"{inputPartOne.Length} units remain after fully reacting the polymer.");

            List<int> polymerLengths = new List<int>();
            for (int i = 65; i < 91; i++)
            {
                var tempPolymer = "";
                for (int j = 0; j < input.Length; j++)
                {
                    if(!((int)input[j] == i || (int)input[j] == i + 32))
                    {
                        tempPolymer += input[j];
                    }
                }
                polymerLengths.Add(ReactingPolymer(tempPolymer).Length);
            }

            Console.WriteLine($"{polymerLengths.Min()} is the length of the shortest polymer.");
        }

        private static string ReactingPolymer(string input)
        {
            var smthChanged = false;
            do
            {
                smthChanged = false;

                var inputTemp = "";
                for (int i = 0; i < input.Length - 1; i++)
                {
                    if ((int)input[i] == (int)input[i + 1] + 32 || (int)input[i] + 32 == (int)input[i + 1])
                    {
                        smthChanged = true;
                        i++;
                    }
                    else
                    {
                        inputTemp += input[i];
                        if (i == input.Length - 2)
                            inputTemp += input[input.Length - 1];
                    }
                }
                input = inputTemp;
            } while (smthChanged);
            return input;
        }
    }
}
