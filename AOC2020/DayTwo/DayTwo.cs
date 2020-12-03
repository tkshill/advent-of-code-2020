using AOC;
using System.Collections.Generic;
using System.Linq;

namespace DayTwo
{
    public readonly struct Token
    {
        public Token(int x, int y, char key, string password)
        {
            First = x;
            Second = y;
            Key = key;
            Password = password;
        }
        public int First { get; }
        public int Second { get; }
        public char Key { get; }
        public string Password { get; }
    }
    public class Result : IResult
    {
        public string filepath() => "./DayTwo/input.txt";

        public string PartOne(IEnumerable<string> input) =>
            input
            .Select(SplitLine)
            .Select(ToToken)
            .Count(x => IsValidPassWord1(x))
            .ToString();

        public string PartTwo(IEnumerable<string> input) =>
            input
            .Select(SplitLine)
            .Select(ToToken)
            .Count(x => IsValidPassWord2(x))
            .ToString();

        public (string, string) AllParts(IEnumerable<string> input) =>
            (PartOne(input), PartTwo(input));

        static (string, string, string) SplitLine(string line)
        {
            var arr = line.Split(" ");
            return (arr[0], arr[1], arr[2]);
        }

        static Token ToToken((string, string, string) input)
        {

            IEnumerable<int> rangeSplit = input.Item1.Split("-").Select(x => int.Parse(x));
            (int pos1, int pos2) = (rangeSplit.First(), rangeSplit.Last());
            char key = input.Item2.First();
            string password = input.Item3;

            return new Token(pos1, pos2, key, password);
        }

        static bool IsValidPassWord1(Token token)
        {
            int count = token.Password.Count(x => x == token.Key);
            return (count >= token.First && count <= token.Second);
        }

        static bool IsValidPassWord2(Token token) =>
            (
                token.Key == token.Password[token.First - 1] ^
                token.Key == token.Password[token.Second - 1]
            );
    }
}

