using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    class Program
    {
        /* { - group begin
         * } - group end
         * < - garbage begin
         * > - garbage end
         * ! - ignore nect char
         * 
         */
        static void Main(string[] args)
        {
            string lineString = File.ReadAllLines(@"input.txt")[0];
            int totalScore = 0;
            int garbageScore = 0;
            int openGroup = 0;
            bool inGarbage = false;
            bool skipNext = false;

            char[] line = lineString.ToCharArray();

            for (int i = 0; i < line.Length; i++)
            {
                if (!skipNext)
                {
                    if (!inGarbage)
                    {
                        switch (line[i])
                        {
                            case '{': openGroup++; break;
                            case '}':
                                totalScore += openGroup;
                                openGroup--; break;
                            case '<': inGarbage = true; break;
                            case '!': skipNext = true; break;
                        }
                    }
                    else
                    {
                        if (line[i] == '>') inGarbage = false;
                        else if(line[i] != '!') garbageScore++;
                        if (line[i] == '!') skipNext = true;
                    }
                }
                else skipNext = false;
            }
            Console.Write("#1: Total score: {0}. \n", totalScore);
            Console.Write("#2: Total garbage score: {0}. \n", garbageScore);
            Console.ReadKey();
        }
    }
}
