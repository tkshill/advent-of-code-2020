using AOC;
using System.Collections.Generic;
using System.Linq;

namespace DayTwo
{
    public class Result : IResult
    {
        public string filepath() => "./DayTwo/input.txt";

        public string PartOne(IEnumerable<string> input) =>
            input
            .Select(SplitLine)
            .Count(x => IsValidPassWord1(x))
            .ToString();

        public string PartTwo(IEnumerable<string> input) =>
            input
            .Select(SplitLine)
            .Count(x => IsValidPassWord2(x))
            .ToString();

        public (string, string) AllParts(IEnumerable<string> input) =>
            (PartOne(input), PartTwo(input));

        static (string, string, string) SplitLine(string line)
        {
            var arr = line.Split(" ");
            return (arr[0], arr[1], arr[2]);
        }

        static bool IsValidPassWord1((string, string, string) token)
        {
            IEnumerable<int> rangeSplit = token.Item1.Split("-").Select(x => int.Parse(x));

            (int startRange, int endRange) = (rangeSplit.First(), rangeSplit.Last());

            char key = token.Item2.First();
            int count = token.Item3.Count(x => x == key);

            return (count >= startRange && count <= endRange);

        }

        static bool IsValidPassWord2((string, string, string) token)
        {
            IEnumerable<int> rangeSplit = token.Item1.Split("-").Select(x => int.Parse(x));

            (int pos1, int pos2) = (rangeSplit.First(), rangeSplit.Last());

            char key = token.Item2.First();
            string password = token.Item3;

            return (key == password[pos1 - 1] ^ key == password[pos2 - 1]);
        }
}
}

