using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BoxId> BoxIds = new List<BoxId>();

            foreach (var id in File.ReadLines(Directory.GetCurrentDirectory() + @"/input"))
            {
                BoxIds.Add(new BoxId(id));
            }

            Console.WriteLine($"Checksum: {BoxIds.Where(x => x.CheckIfNTimes(2)).Count() * BoxIds.Where(x => x.CheckIfNTimes(3)).Count()}");

            for (int i = 0; i < BoxIds.Count; i++)
            {
                for (int j = 0; j < BoxIds.Count; j++)
                {
                    if (!BoxIds[i].boxId.Equals(BoxIds[j].boxId))
                    {
                        var differCount = 0;

                        for (int k = 0; k < BoxIds[i].boxId.Length; k++)
                        {
                            differCount += !BoxIds[i].boxId[k].Equals(BoxIds[j].boxId[k]) ? 1 : 0;
                        }

                        if (differCount == 1)
                        {
                            Console.WriteLine("Common letters: ");

                            for (int k = 0; k < BoxIds[i].boxId.Length; k++)
                            {
                                Console.Write(BoxIds[i].boxId[k].Equals(BoxIds[j].boxId[k]) ? BoxIds[j].boxId[k].ToString() : "");
                                return;
                            }
                        }
                    }
                }
            }
        }
    }

    class BoxId
    {
        public string boxId;

        public BoxId(string id)
        {
            boxId = id;
        }

        public bool CheckIfNTimes(int n)
        {
            Dictionary<char, int> letters = new Dictionary<char, int>();

            for (int i = 0; i < boxId.Length; i++)
            {
                if (letters.ContainsKey(boxId[i]))
                {
                    letters[boxId[i]] += 1;
                }
                else
                {
                    letters.Add(boxId[i], 1);
                }
            }

            return letters.Values.Contains(n);
        }
    }
}
