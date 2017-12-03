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
            List<int> summands = new List<int>();
            List<int> summands2 = new List<int>();
            String input;
            String input2;
            Char[] puzzle;
            Char[] puzzle2;

            Console.Write("Insert puzzle: ");

            Stream inputStream = Console.OpenStandardInput(4096); 
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, 4096));
            input = Console.ReadLine();
            puzzle = new char[input.Length];
            puzzle = input.ToCharArray();

            for (int i = 0; i < puzzle.Length - 1; i++)
                if (puzzle[i] == puzzle[i + 1])
                    summands.Add((int)puzzle[i] - '0');

            if (puzzle[puzzle.Length-1] == puzzle[0])
                summands.Add((int)puzzle[0] - '0');

            Console.Write("The Awnser is: {0} ", summands.Sum()); 

            Console.WriteLine("\n\n -----Second Part:\n Insert Puzzle: ");

            //inputStream = Console.OpenStandardInput(4096);
            //Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, 4096));
            input2 = Console.ReadLine();
            puzzle2 = input2.ToCharArray();

            int next = puzzle2.Length / 2;
            for (int i = 0; i < puzzle2.Length ; i++)
                if (puzzle2[i] == puzzle2[(i + next) % puzzle2.Length])
                    summands2.Add((int)puzzle2[i] - '0');

            Console.Write("The Awnser is: {0} ", summands2.Sum());

            Console.ReadKey();
        }
    }
}
