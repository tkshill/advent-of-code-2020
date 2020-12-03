#nullable enable annotations
#nullable enable warnings

using AOC;
using System.Collections.Generic;
using System.Linq;

namespace DayThree
{
    public class Result : IResult
    {
        static char tree = '#';
        public string filepath() => "./DayThree/input.txt";

        public string PartOne(IEnumerable<string> input) =>
            TreeCount((3, 1), input).ToString();

        public string PartTwo(IEnumerable<string> input) =>
            new[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) }
            .Select(x => TreeCount(x, input))
            .Select(x => (uint)x)
            .Aggregate((uint)1, (prod, next) => prod * next)
            .ToString();

        public (string, string) AllParts(IEnumerable<string> input) =>
            (PartOne(input), PartTwo(input));

        static int TreeCount((int shiftLeft, int shiftDown) shift, IEnumerable<string> input)
        {
            int rows = input.Count();
            int columns = input.First().Length;
            int duplicates = (shift.shiftLeft * rows) / (columns * shift.shiftDown) + 1;
            int advancement = columns * duplicates * shift.shiftDown + shift.shiftLeft;

            return input
                .SelectMany(x => Enumerable.Repeat(x, duplicates))
                .SelectMany(x => x)
                .Where((c, index) => index % advancement == 0)
                .Count(x => x == tree);
        }
    }
}
