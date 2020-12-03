#nullable enable annotations
#nullable enable warnings

using System.Collections.Generic;

namespace AOC
{
    public interface IResult
    {
        string filepath();
        string PartOne(IEnumerable<string> input);
        string PartTwo(IEnumerable<string> input);
        (string, string) AllParts(IEnumerable<string> input);
    }
}