using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> inputList = File.ReadLines(@"input.txt").ToList();
            int[] steps = new int[inputList.Count];
            int[] steps2 = new int[inputList.Count];
            int count = 0;

            for (int i = 0; i < inputList.Count; i++)
            {
                steps[i] = Convert.ToInt32(inputList[i]);
                steps2[i] = Convert.ToInt32(inputList[i]);
            }

            int oldPos = 0;

            try
            {
                for (int i = 0; ;)
                {
                    i += steps[i];
                    steps[oldPos] += 1;
                    oldPos = i;
                    count++;
                }
            }
            catch (Exception e)
            {
                Console.Write("#1: It took {0} steps to reach the exit. ", count);
            }

            count = 0;
            oldPos = 0;

            try
            {
                for (int i = 0; ;)
                {
                    i += steps2[i];
                    steps2[oldPos] += (steps2[oldPos] >= 3 ? -1 : 1);
                    //if (steps2[oldPos] >= 3)
                    //    steps2[oldPos]--;
                    //else
                    //    steps2[oldPos]++;
                    oldPos = i;
                    count++;
                }
            }
            catch (Exception e)
            {
                Console.Write("\n#2: It took {0} steps to reach the exit. ", count);
            }


            Console.ReadKey();
        }
    }
}
