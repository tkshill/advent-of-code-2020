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

        /*
        Part two just iterates through array of traversals,
        calling the TreeCount method on each,
        then multiplying the results.

        I got a negative number at first which was weird, but then I realized that
        Int was too small so I had to convert to unsigned ints
        */
        public string PartTwo(IEnumerable<string> input) =>
            new[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) }
            .Select(x => (uint)TreeCount(x, input))
            .Aggregate((uint)1, (prod, next) => prod * next)
            .ToString();

        public (string, string) AllParts(IEnumerable<string> input) =>
            (PartOne(input), PartTwo(input));

        static int TreeCount((int shiftLeft, int shiftDown) shift, IEnumerable<string> input)
        {
            // number of lines of original input
            int rows = input.Count();

            // length of each line
            int columns = input.First().Length;

            // How often will the input list "repeat"
            int duplicates = (shift.shiftLeft * rows) / (columns * shift.shiftDown) + 1;

            // how far the 'cursor' will move each time
            int advancement = columns * duplicates * shift.shiftDown + shift.shiftLeft;

            return input
                .SelectMany(x => Enumerable.Repeat(x, duplicates))  // repeat each row
                .SelectMany(x => x)                                 // convert to stream of characters
                .Where((c, index) => index % advancement == 0)      // filter for indices that toboggan jumps to
                .Count(x => x == tree);                             // count the ones that are trees
        }
    }
}
