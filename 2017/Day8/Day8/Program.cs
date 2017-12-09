using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> register = new Dictionary<string, int>();

            List<string> input = File.ReadLines(@"input.txt").ToList();

            int maxValue = 0;

            foreach (string line in input)
            {
                string[] lineString = line.Split(' ');

                bool condition = false;

                if (!register.ContainsKey(lineString[4]))
                    register.Add(lineString[4], 0);
                if (!register.ContainsKey(lineString[0]))
                    register.Add(lineString[0], 0);

                int value = 0;

                register.TryGetValue(lineString[4], out value);
                switch (lineString[5])
                {
                    case ">": condition = value > Convert.ToInt32(lineString[6]) ? true : false; break;
                    case "<": condition = value < Convert.ToInt32(lineString[6]) ? true : false; break;
                    case "==": condition = value == Convert.ToInt32(lineString[6]) ? true : false; break;
                    case ">=": condition = value >= Convert.ToInt32(lineString[6]) ? true : false; break;
                    case "<=": condition = value <= Convert.ToInt32(lineString[6]) ? true : false; break;
                    case "!=": condition = value != Convert.ToInt32(lineString[6]) ? true : false; break;
                }

                if (condition)
                {
                    switch (lineString[1])
                    {
                        case "inc": register[lineString[0]] += Convert.ToInt32(lineString[2]); break;
                        case "dec": register[lineString[0]] -= Convert.ToInt32(lineString[2]); break;
                    }
                }

                if (register.Values.Max() > maxValue) maxValue = register.Values.Max();
            }

            Console.Write("#1: {0} is the largest value. \n", register.Values.Max());
            Console.Write("#2: {0} is the largest value. \n", maxValue);
            Console.ReadKey();
        }
    }
}

