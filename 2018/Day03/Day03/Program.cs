using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputStrings = File.ReadLines(Directory.GetCurrentDirectory() + @"/input").ToList();

            int[,] fieldArray = new int[10000, 10000];


            foreach (var patch in inputStrings)
            {
                if (patch != "")
                {
                    var temp = patch.Split('@')[1].Trim();
                    var start = temp.Split(':')[0].Trim();
                    var size = temp.Split(':')[1].Trim();

                    for (int row = Convert.ToInt32(start.Split(',')[1].Trim()); row < Convert.ToInt32(size.Split('x')[1].Trim()); row++)
                    {
                        for (int column = Convert.ToInt32(start.Split(',')[0].Trim()); column < Convert.ToInt32(size.Split('x')[0].Trim()); column++)
                        {
                            fieldArray[row, column] += 1;
                        }
                    }
                }
            }

            var count = 0;
            for (int i = 0; i < 10000; i++)
            {
                for (int j = 0; j < 10000; j++)
                {
                    if (fieldArray[i, j] > 1)
                        count++;
                }
            }
            Console.WriteLine($"{count} square inches of fabric are within two or more claims.");
        }
    }
}
