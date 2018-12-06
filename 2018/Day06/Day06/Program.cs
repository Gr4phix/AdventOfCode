using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputStrings = File.ReadLines(Directory.GetCurrentDirectory() + @"/input").ToList();
            var pointList = new List<Point>();

            foreach (var point in inputStrings)
            {
                if (point != "")
                    pointList.Add(new Point(Convert.ToInt32(point.Split(',')[0].Trim()), Convert.ToInt32(point.Split(',')[1].Trim())));
            }

            var field = new int[pointList.Max(x => x.X) + 1, pointList.Max(x => x.Y) + 1];

            foreach (var point in pointList)
            {
                field[point.X, point.Y] = point.GetHashCode();
            }

            var totalDistanceDirectory = new Dictionary<int, int>();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    var tempDictionary = new Dictionary<int, int>();

                    foreach (var point in pointList)
                    {
                        var distance = Math.Abs(point.X - i) + Math.Abs(point.Y - j);
                        tempDictionary.Add(point.GetHashCode(), distance);
                    }

                    field[i, j] = tempDictionary.Count(x => x.Value == tempDictionary.Values.Min()) > 1
                        ? -1
                        : tempDictionary.Single(x => x.Value == tempDictionary.Values.Min()).Key;

                    if (totalDistanceDirectory.Keys.Contains(field[i, j]))
                    {
                        totalDistanceDirectory[field[i, j]] += 1;
                    }
                    else
                    {
                        totalDistanceDirectory.Add(field[i, j], 1);
                    }

                    if (i == 0 || j == 0 || i == field.GetLength(0) - 1 || j == field.GetLength(1) - 1)
                    {
                        totalDistanceDirectory[field[i, j]] -= 10000;
                    }
                }
            }

            Console.WriteLine($"{totalDistanceDirectory.Values.Max()} is the size of the largest area.");

            //Part 2:
            var regionSize = 0;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    var distance = 0;

                    foreach (var point in pointList)
                    {
                        distance += Math.Abs(point.X - i) + Math.Abs(point.Y - j);
                    }

                    if (distance < 10000)
                        regionSize += 1;
                }
            }
            Console.WriteLine($"{regionSize} is the size of the region containing all locations which have a total distance to all given coordinates of less than 10000.");
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
