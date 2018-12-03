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

            int[,] fieldArray = new int[5000, 5000];

            foreach (var patch in inputStrings)
            {
                if (patch != "")
                {
                    var temp = patch.Split('@')[1].Trim();
                    var start = temp.Split(':')[0].Trim();
                    var size = temp.Split(':')[1].Trim();

                    for (int row = Convert.ToInt32(start.Split(',')[1].Trim()); row < Convert.ToInt32(size.Split('x')[1].Trim()) + Convert.ToInt32(start.Split(',')[1].Trim()); row++)
                    {
                        for (int column = Convert.ToInt32(start.Split(',')[0].Trim()); column < Convert.ToInt32(size.Split('x')[0].Trim()) + Convert.ToInt32(start.Split(',')[0].Trim()); column++)
                        {
                            fieldArray[row, column] += 1;
                        }
                    }
                }
            }

            var count = 0;
            for (int i = 0; i < fieldArray.GetLength(0); i++)
            {
                for (int j = 0; j < fieldArray.GetLength(1); j++)
                {
                    if (fieldArray[i, j] > 1)
                        count++;
                }
            }
            Console.WriteLine($"{count} square inches of fabric are within two or more claims.");


            //Part two:
            foreach (var patch in inputStrings)
            {
                if (patch != "")
                {
                    var temp = patch.Split('@')[1].Trim();
                    var start = temp.Split(':')[0].Trim();
                    var size = temp.Split(':')[1].Trim();

                    var overlapping = false;

                    for (int row = Convert.ToInt32(start.Split(',')[1].Trim()); row < Convert.ToInt32(size.Split('x')[1].Trim()) + Convert.ToInt32(start.Split(',')[1].Trim()); row++)
                    {
                        for (int column = Convert.ToInt32(start.Split(',')[0].Trim()); column < Convert.ToInt32(size.Split('x')[0].Trim()) + Convert.ToInt32(start.Split(',')[0].Trim()); column++)
                        {
                            if (fieldArray[row, column] > 1)
                                overlapping = true;
                        }
                    }

                    if(!overlapping)
                    {
                        Console.WriteLine($"{patch.Split('@')[0].Trim()} the ID of the only claim that doesn't overlap.");
                        return;
                    }
                }
            }
        }
    }
}
