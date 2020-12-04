#nullable enable annotations
#nullable enable warnings

using System;
using Results;
using static Results.Results;
using System.Collections.Generic;
using System.IO;

namespace AOC2020
{
    class Program
    {
        static (string, string) RunDay(Day day)
        {
            var result = day switch
            {
                Day.One => Day1(),
                Day.Two => Day2(),
                Day.Three => Day3(),
                Day.Four => Day4(),
                Day.Five => Day5(),
                Day.Six => Day6(),
                Day.Seven => Day7(),
                Day.Eight => Day8(),
                Day.Nine => Day9(),
                Day.Ten => Day10(),
                Day.Eleven => Day11(),
                _ => throw new ArgumentOutOfRangeException("That Day has not been implemented.")
            };

            IEnumerable<string> input = File.ReadAllLines(result.filepath());
            return result.AllParts(input);
        }
        static void Main(string[] args)
        {
            (var part1, var part2) = RunDay(Day.Three);

            Console.WriteLine("Part One result is: {0}\nPart Two result is: {1}", part1, part2);
        }
    }
}
