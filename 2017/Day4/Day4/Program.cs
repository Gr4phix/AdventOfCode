using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> lines = File.ReadLines(@"input.txt").ToList();
            int passphraseCount = 0;

            foreach (String line in lines)
            {
                String[] phrase = line.Split(new Char[] { ' ' });
                int help = -1;
                bool found = false;

                for (int i = 0; i < phrase.Length; i++)
                {
                    help = -1; 

                    for (int l = 0; l < phrase.Length; l++)
                    {
                        if (phrase[i] == phrase[l])
                        {
                            help++;
                        }
                    }

                    if (help > 0)
                        found = true;
                }

                if (!found)
                {
                    passphraseCount++;
                }
            }

            Console.Write("There are {0} correct passphrases with the first system policy. ", passphraseCount);

            passphraseCount = 0;
            foreach (String line in lines)
            {
                String[] phrase = line.Split(new Char[] { ' ' });
                int help = -1;
                bool found = false;

                for (int i = 0; i < phrase.Length; i++)
                {
                    help = -1;

                    for (int l = 0; l < phrase.Length; l++)
                    {
                        if (phrase[i] == phrase[l] || !(((phrase[i] + phrase[l]).Any(c => phrase[i].Count(x => x == c) != phrase[l].Count(x => x == c)))))
                        {
                            help++;
                        }
                    }

                    if (help > 0)
                        found = true;
                }

                if (!found)
                {
                    passphraseCount++;
                }
            }

            Console.Write("\n\nThere are {0} correct passphrases with the second system policy. ", passphraseCount);
            Console.ReadKey();
        }
    }
}
