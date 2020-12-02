using System.Collections.Generic;

namespace Core
{
    interface Result
    {
        string filepath();
        string PartOne(IEnumerable<string> input);
        string PartTwo(IEnumerable<string> input);
        (string, string) AllParts(IEnumerable<string> input);
    }
}