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
            new[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) }        // make array of shifts
            .Select(x => (uint)TreeCount(x, input))                 // get the number of trees for each
            .Aggregate((uint)1, (prod, next) => prod * next)        // multiply the results
            .ToString();

        public (string, string) AllParts(IEnumerable<string> input) =>
            (PartOne(input), PartTwo(input));

        static int TreeCount((int left, int down) shift, IEnumerable<string> input)
        {
            int rows = input.Count();                               // number of lines of original input
            int columns = input.First().Length;                     // length of each line
            int duplicates =                                        // How often will the input list "repeat"
                (shift.left * rows) / (columns * shift.down) + 1;
            int advancement =                                       // how far the 'cursor' will move each time
                columns * duplicates * shift.down + shift.left;

            return input
                .SelectMany(x => Enumerable.Repeat(x, duplicates))  // repeat each row
                .SelectMany(x => x)                                 // convert to stream of characters
                .Where((c, index) => index % advancement == 0)      // filter for indices that toboggan jumps to
                .Count(x => x == tree);                             // count the ones that are trees
        }
    }
}
