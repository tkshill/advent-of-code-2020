using System;
using Results;
using static Results.Results;
using System.Collections.Generic;
using System.IO;
using AOC;

namespace AOC2020
{

    class Program
    {
        static (string, string) Run(IResult result)
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
            IResult result;

            day switch
            {
                Day.One => result = Day1(),
                Day.Two => result = Day2(),
                _ => throw new ArgumentOutOfRangeException("That Day has not been implemented.");
            };
            return Run(result);
        }
        static void Main(string[] args)
        {
            (string part1, string part2) = RunDay(Day.One);

            Console.WriteLine("Part one result is: {0}\nPart Two result is: {1}", part1, part2);
        }
    }
}
