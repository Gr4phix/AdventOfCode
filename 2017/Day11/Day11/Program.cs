using System;
using System.Collections.Generic;
using System.IO;

namespace Day11
{
    class Program
    {
        enum Direction { north, northEast, southEast, south, southWest, northWest}

        static void Main(string[] args)
        {
            string line = File.ReadAllLines(@"input.txt")[0];

            string[] dirArray = line.Split(new Char[] { ',' });

            List<Direction> dirs = new List<Direction>();           
            for (int i = 0; i < dirArray.Length; i++)
            {
                switch(dirArray[i])
                {
                    case "n": dirs.Add(Direction.north); break;
                    case "ne": dirs.Add(Direction.northEast); break;
                    case "se": dirs.Add(Direction.southEast); break;
                    case "s": dirs.Add(Direction.south); break;
                    case "sw": dirs.Add(Direction.southWest); break;
                    case "nw": dirs.Add(Direction.northWest); break;
                }
            }

            int x = 0, y = 0;
            int distance = 0;
            int maxDistance = 0;
            foreach (Direction dir in dirs)
            {
                switch (dir)
                {
                    case Direction.north: y--; break;
                    case Direction.northEast: x++; y--; break;
                    case Direction.southEast: x++; break;
                    case Direction.south: y++; break;
                    case Direction.southWest: x--; y++; break;
                    case Direction.northWest: x--; break;
                }
                distance = Math.Sign(x) == Math.Sign(y) ? Math.Abs(x + y) : Math.Max(Math.Abs(x), Math.Abs(y));
                maxDistance = maxDistance < distance ? distance : maxDistance;
            }
            Console.Write("#1: Distance: {0} \n", distance);
            Console.Write("#2: Max Distance: {0} ", maxDistance);
            Console.ReadKey();
        }
    }
}
