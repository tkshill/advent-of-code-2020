using System;
using Results;
using static Results.Results;
using System.Collections.Generic;
using System.IO;

namespace AOC2020
{
    class Program
    {
        static IEnumerable<string> FetchData(String filepath)
        {
            try
            {
                return File.ReadAllLines(filepath);
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
            var result = day switch
            {
                Day.One => Day1(),
                Day.Two => Day2(),
                _ => throw new ArgumentOutOfRangeException("That Day has not been implemented.")
            };
            var input = FetchData(result.filepath());
            return result.AllParts(input);
        }
        static void Main(string[] args)
        {
            (var part1, var part2) = RunDay(Day.One);

            Console.WriteLine("Part one result is: {0}\nPart Two result is: {1}", part1, part2);
        }
    }
}
