using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var instructions = File.ReadLines(Directory.GetCurrentDirectory() + @"/input").ToList()[0].Split(", ");
            foreach (var ins in instructions)
            {
                ins.Trim();
            }

            var directionDistance = new Dictionary<EDirection, int>
            {
                { EDirection.N, 0 },
                { EDirection.E, 0 },
                { EDirection.S, 0 },
                { EDirection.W, 0 }
            };
            var currentDir = EDirection.N;
            var alreadySeenLocations = new List<Coordinate>();
            foreach (var instruction in instructions)
            {
                switch (currentDir)
                {
                    case EDirection.N:
                        currentDir = instruction[0].Equals('L') ? EDirection.W : EDirection.E;
                        break;
                    case EDirection.E:
                        currentDir = instruction[0].Equals('L') ? EDirection.N : EDirection.S;
                        break;
                    case EDirection.S:
                        currentDir = instruction[0].Equals('L') ? EDirection.E : EDirection.W;
                        break;
                    case EDirection.W:
                        currentDir = instruction[0].Equals('L') ? EDirection.S : EDirection.N;
                        break;
                }

                for (int i = 0; i < Convert.ToInt32(instruction.Substring(1)); i++)
                {
                    directionDistance[currentDir]++;

                    var foundIt = false;
                    var currentCoord = new Coordinate(directionDistance);
                    foreach (var loc in alreadySeenLocations)
                    {
                        foundIt |= loc.Equals(currentCoord);
                    }
                    if (foundIt)
                    {
                        var distance = CalculateDistance(directionDistance);
                        Console.WriteLine($"Been here already: {instruction}, Distance: {distance}");
                    }
                    else
                    {
                        alreadySeenLocations.Add(currentCoord);
                    }
                }
            }

            var finalDistance = CalculateDistance(directionDistance);
            Console.WriteLine(finalDistance);
        }

        public static int CalculateDistance(Dictionary<EDirection, int> directionDistance)
        {
            var distance = 0;
            distance += directionDistance[EDirection.N] > directionDistance[EDirection.S] ? directionDistance[EDirection.N] - directionDistance[EDirection.S] : directionDistance[EDirection.N] < directionDistance[EDirection.S] ? directionDistance[EDirection.S] - directionDistance[EDirection.N] : 0;
            distance += directionDistance[EDirection.W] > directionDistance[EDirection.E] ? directionDistance[EDirection.W] - directionDistance[EDirection.E] : directionDistance[EDirection.W] < directionDistance[EDirection.E] ? directionDistance[EDirection.E] - directionDistance[EDirection.W] : 0;
            return distance;
        }

        public class Coordinate {
            public int X { get; private set; }
            public int Y { get; private set; }

            public Coordinate(Dictionary<EDirection, int> dirDis) {
                X = dirDis[EDirection.N] - dirDis[EDirection.S];
                Y = dirDis[EDirection.E] - dirDis[EDirection.W];
            }

            public override bool Equals(object obj)
            {
                var scndCoord = (Coordinate)obj;
                return X == scndCoord.X && Y == scndCoord.Y;
            }
        }

        public enum EDirection {
            N,
            E, 
            S, 
            W
        }   
    }
}
