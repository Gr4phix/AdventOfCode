using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream inputStream = Console.OpenStandardInput(10000);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, 10000));
            String input = Console.ReadLine();
            char[] puzzle = input.ToCharArray();

            int floor = 0;
            bool secondPart = true;

            for (int i = 0; i < puzzle.Length; i++)
            {
                if (puzzle[i] == '(') floor++;
                else floor--;

                if (floor == -1 && secondPart)
                {
                    Console.Write("He enterd the basement in character {0}. \n ", i + 1);
                    secondPart = false;
                }
            }

            Console.Write("He's now in floor {0}. ", floor);
            
            Console.ReadKey();
        }
    }
}
