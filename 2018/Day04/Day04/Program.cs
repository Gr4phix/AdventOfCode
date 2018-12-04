using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputStrings = File.ReadLines(Directory.GetCurrentDirectory() + @"/input");

            var sortedInput = inputStrings.OrderBy(x => Convert.ToInt32(x.Split(' ')[0].Substring(1).Split('-')[0])) //Year
                .ThenBy(x => Convert.ToInt32(x.Split(' ')[0].Substring(1).Split('-')[1])) //Month
                .ThenBy(x => Convert.ToInt32(x.Split(' ')[0].Substring(1).Split('-')[2])) //Day
                .ThenBy(x => Convert.ToInt32(x.Split(' ')[1].Split(':')[0])) //Hour
                .ThenBy(x => Convert.ToInt32(x.Split(' ')[1].Split(':')[1].Remove(2))).ToList(); //Minute

            List<Shift> record = new List<Shift>();
            foreach (var instruction in sortedInput)
            {
                switch (instruction.Split(' ')[2])
                {
                    case "Guard":
                        record.Add(new Shift(instruction.Split(' ')[0].Substring(1), instruction.Split(' ')[3]));
                        break;
                    case "falls":
                        record.Last().SleepBegin = Convert.ToInt32(instruction.Split(' ')[1].Split(':')[1].Remove(2));
                        break;
                    case "wakes":
                            for (int i = record.Last().SleepBegin; i < Convert.ToInt32(instruction.Split(' ')[1].Split(':')[1].Remove(2)); i++)
                            {
                                record.Last().Sleeping[i] = true;
                            }
                        break;
                    default:
                        Console.WriteLine("Error.");
                        break;
                }
            }

            //var mostSleepingGuardId = record.Single(x => x.CalculateMinutesAsleep()==record.Max(y => y.CalculateMinutesAsleep())).Id;
            string mostSleepingGuardId = "";
            foreach (var item in record)
            {
                if (item.CalculateMinutesAsleep() == record.Max(y => y.CalculateMinutesAsleep()))
                {
                    mostSleepingGuardId = item.Id;
                    break;
                }
            }

            var timesAsleepInThisMinute = new List<int>();
            for (int i = 0; i < 60; i++)
            {
                timesAsleepInThisMinute.Add(0);
            }
            foreach (var shift in record.Where(x => x.Id.Equals(mostSleepingGuardId)))
            {
                for (int i = 0; i < 60; i++)
                {
                    timesAsleepInThisMinute[i] += shift.Sleeping[i] ? 1 : 0;
                }
            }
            Console.WriteLine(mostSleepingGuardId + ", " + timesAsleepInThisMinute.IndexOf(timesAsleepInThisMinute.Max()) + ", " + String.Join(',', timesAsleepInThisMinute));
            Console.WriteLine($"{timesAsleepInThisMinute.IndexOf(timesAsleepInThisMinute.Max()) * Convert.ToInt32(mostSleepingGuardId.Substring(1))}");
        }
    }

    class Shift
    {
        public string Date { get; set; }
        public string Id { get; set; }
        public List<bool> Sleeping { get; set; }
        public int SleepBegin { get; set; }
        public int MinutesAsleep { get; private set; }

        public Shift(string date, string id)
        {
            Date = date;
            Id = id;
            Sleeping = new List<bool>();
            for (int i = 0; i < 60; i++)
            {
                Sleeping.Add(false);
            }
        }

        public int CalculateMinutesAsleep()
        {
            var temp = 0;
            foreach (var time in Sleeping)
            {
                if (time) temp++;
            }
            MinutesAsleep = temp;
            return temp;
        }
    }
}
