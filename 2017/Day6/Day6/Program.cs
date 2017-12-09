using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = File.ReadAllLines(@"input.txt")[0];

            string[] blocksArray = line.Split(new Char[] { ' ' });

            List<int> blocks = new List<int>();
            for (int i = 0; i < blocksArray.Length; i++)
            {
                blocks.Add(Convert.ToInt32(blocksArray[i]));
            }

            int length = blocks.Count;
            List<List<int>> help = new List<List<int>>();
            bool finish = false;

            int count = 0;
            do
            {
                int max = blocks.Max();
                int index = blocks.IndexOf(max);

                blocks[index] = 0;             

                for (int i = ((index+=1) >= length ? 0 : index++); max > 0; max--)
                {                                     
                    blocks[i] = blocks[i] + 1;

                    i++;
                    if (i >= length) i = 0;

                    Console.WriteLine("{0} : {1} --- {2}", max, String.Join(", ", blocks), count);
                    Console.ReadKey();
                }
                Console.WriteLine("{0} : {1} --- {2}", 0, String.Join(", ", blocks), count);
                Console.ReadKey();
                count++;

                foreach (List<int> lists in help)
                {
                    if(blocks.SequenceEqual(lists))
                    {
                        finish = true;
                    }
                }

                if(!finish)
                help.Add(blocks);

            } while (!finish);

            Console.Write("#1: {0} redistribution cycles needed. ", count);

            Console.ReadKey();
        }
    }
}
