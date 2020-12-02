using System;
using DayTwo;
using System.Collections.Generic;
using System.IO;
using Core;

namespace AOC2020
{
    public enum Day
    {
        Two
    }

    class Program
    {
        static (string, string) Run(Result result)
        {
            try
            {
                IEnumerable<string> input = File.ReadAllLines(result.filepath());
                return result.AllParts(input);
            }
            catch (IOException e)
            {
                if (e.Source is not null)
                    Console.WriteLine("Check that file path buddy. {0}", e.Source);
                throw e;
            }
        }
        static (string, string) RunDay(Day day)
        {
            Result result;

            if (day == Day.Two)
            {
                result = new DayTwoResult();
            }
            else
            {
                throw new ArgumentOutOfRangeException("That Day has not been implemented yet.");
            }
            return Run(result);
        }
        static void Main(string[] args)
        {
            (string part1, string part2) = RunDay(Day.Two);

            Console.WriteLine("Part one result is: {0}\nPart Two result is: {1}", part1, part2);
        }
    }
}
