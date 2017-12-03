using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> lines = File.ReadLines(@"input.txt").ToList();
            int sum = 0;
            int ribbonSum = 0;

            foreach (String line in lines)
            {
                char[] cLine = line.ToCharArray();
                int x1 = 0;
                int x2 = 0;

                for(int i = 0; i < cLine.Length; i++)
                {
                    if (cLine[i] == 'x' && x1 == 0) x1 = i;
                    if (cLine[i] == 'x' && x1 != 0) x2 = i;
                }

                String l = "", w="", h="";
                for (int i = 0; i < x1; i++) l += cLine[i];
                for (int i = x1+1; i < x2; i++) w += cLine[i];
                for (int i = x2+1; i < cLine.Length; i++) h += cLine[i];

                Console.WriteLine("{0}, {1}, {2}", l, w, h);

                int il, iw, ih;
                il = Convert.ToInt32(l);
                iw = Convert.ToInt32(w);
                ih = Convert.ToInt32(h);

                List<int> dim = new List<int>();
                dim.Add(il * iw);
                dim.Add(iw * ih);
                dim.Add(ih * il);

                sum += 2 * il * iw + 2 * iw * ih + 2 * ih * il;
                sum += dim.Min();

                List<int> dim2 = new List<int>();
                dim2.Add(il);
                dim2.Add(iw);
                dim2.Add(ih);

                ribbonSum += il * iw * ih;
                ribbonSum += 2 * dim2.Min();
                dim2.Remove(dim2.Min());
                ribbonSum += 2 * dim2.Min();


            }
            Console.Write("The elves need {0} feet of wraping paper and {1} feet of ribbon. ", sum, ribbonSum);

            Console.ReadKey();
        }
    }
}
