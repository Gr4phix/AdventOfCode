using System;
using System.Collections.Generic;
using System.IO;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            string lengthsString = File.ReadAllLines(@"input.txt")[0];
            string[] lengthsString2 = lengthsString.Split(new Char[] { ',' });
            List<int> lengths = new List<int>();
            foreach (string length in lengthsString2)
                lengths.Add(Convert.ToInt32(length));

            List<int> list = new List<int>();
            int listLength = 256;

            for (int i = 0; i < listLength; i++)
            {
                list.Add(i);
            }

            Console.Write("{0} --- {1} \n", String.Join(", ", list), String.Join(", ", lengths));

            int cPos = 0, skipSize = 0;
            do
            {
                List<int> help = new List<int>();
                int pos = cPos;
                for (int i = 0; i < lengths[0]; i++)
                {
                    help.Add(Convert.ToInt32(list[pos].ToString()));

                    pos++;
                    if (pos == list.Count) pos = 0;
                }

                help.Reverse();

                pos = cPos;
                for (int i = 0; i < lengths[0]; i++)
                {
                    list[pos] = help[0];
                    help.RemoveAt(0);

                    pos++;
                    if (pos == list.Count) pos = 0;
                }
                
                Console.Write("{0} --- {1} \n", String.Join(", ", list), String.Join(", ", lengths));
                //Console.ReadKey();

                cPos = (cPos + lengths[0] + skipSize) % list.Count;
                lengths.RemoveAt(0);
                skipSize++;

                Console.Write("{0} --- {1} \n", cPos, String.Join(", ", lengths));
                //Console.ReadKey();
            } while (lengths.Count > 0);

            Console.Write("#1: Multiplying the first two numbers in the list results: {0}. \n", list[0] * list[1]);
            Console.ReadKey();

            char[] helppp = lengthsString.ToCharArray();
            List<int> lengthsChar = new List<int>();
            foreach (char charr in helppp)
            {
                lengthsChar.Add((int)charr);
            }
            lengthsChar.Add(17);
            lengthsChar.Add(31);
            lengthsChar.Add(73);
            lengthsChar.Add(47);
            lengthsChar.Add(23);

            List<int> list2 = new List<int>();
            int listLength2 = 256;

            for (int i = 0; i < listLength2; i++)
            {
                list2.Add(i);
            }

            cPos = skipSize = 0;

            int rounds = 64;
            List<int> lengthsHelp = new List<int>();
            do
            {                
                foreach (int helpppp in lengthsChar)
                    lengthsHelp.Add(helpppp);
                do
                {
                    List<int> help = new List<int>();
                    int pos = cPos;
                    for (int i = 0; i < lengthsChar[0]; i++)
                    {
                        help.Add(Convert.ToInt32(list[pos].ToString()));

                        pos++;
                        if (pos == list2.Count) pos = 0;
                    }

                    help.Reverse();

                    pos = cPos;
                    for (int i = 0; i < help.Count; i++)
                    {
                        list2[pos] = help[0];
                        help.RemoveAt(0);

                        pos++;
                        if (pos == list.Count) pos = 0;
                    }

                    Console.Write("{0} --- {1} \n", String.Join(", ", list), String.Join(", ", lengthsHelp));
                    //Console.ReadKey();

                    cPos = (cPos + lengthsHelp[0] + skipSize) % list.Count;
                    lengthsHelp.RemoveAt(0);
                    skipSize++;

                    Console.Write("{0} --- {1} ------- {2} \n", cPos, String.Join(", ", lengthsHelp), rounds);
                    //Console.ReadKey();
                } while (lengthsHelp.Count > 0);
                rounds--;
            } while (rounds > 0);

            Console.Write("#2: sparse hash: {0} \n", String.Join(", ", list2));

            List<int> denseHash = new List<int>();
            for (int i = 0; i < 16; i++)
            {
                int help = 0;
                for (int l = 0; l < 16; l++)
                {
                    help ^= list2[i * l];
                }
                denseHash.Add(help);
            }

            Console.Write("#2: dense hash: {0} \n", String.Join(", ", denseHash));

            string answer = "";
            for (int i = 0; i < denseHash.Count; i++)
            {
                answer += denseHash[i].ToString("X");
            }

            Console.Write("#2: The knot hash is: {0}. \n", answer);
            Console.WriteLine("{0}", (65 ^ 27 ^ 9 ^ 1 ^ 4 ^ 3 ^ 40 ^ 50 ^ 91 ^ 7 ^ 6 ^ 0 ^ 2 ^ 5 ^ 68 ^ 22).ToString("X") + (7).ToString("X"));
            Console.ReadKey();
        }
    }
}
