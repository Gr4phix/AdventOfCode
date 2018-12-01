using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputStrings = File.ReadLines(Directory.GetCurrentDirectory() + @"/input").ToList();

            List<int> input = new List<int>();
            foreach (var number in inputStrings)
            {
                input.Add(Convert.ToInt32(number));
            }

            Console.WriteLine($"Resulting frequency: {input.Sum()}");

            //Part two:
            List<int> alreadyReachedFrequencys = new List<int>();
            var sum = 0;
            var counter = 0;
            while(true)
            {
                sum += input[counter];

                if(alreadyReachedFrequencys.Contains(sum))
                {
                    Console.WriteLine($"Already visited this frequency: {sum}");
                    return;
                }

                alreadyReachedFrequencys.Add(sum);

                counter = (counter + 1) % input.Count;
            }
        }
    }
}
