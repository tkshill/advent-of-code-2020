using System.Collections.Generic;
using System.Linq;
using AOC;

namespace DayFour
{
    public enum Cred { byr, iyr, eyr, hgt, hcl, ecl, pid, cid }
    public class Result : IResult
    {
        public string filepath() => "./DayFour/input.txt";

        static IEnumerable<Cred> creds() =>
            new Cred[] { Cred.byr, Cred.iyr, Cred.eyr, Cred.hgt, Cred.hcl, Cred.ecl, Cred.pid, Cred.cid }
            .AsEnumerable();

        public string PartOne(IEnumerable<string> input) =>
            (Chunkify(input))
            .Where(IsLongEnough)
            .Where(IsValidCredential1)
            .Count()
            .ToString();

        public string PartTwo(IEnumerable<string> input) =>
            "Not Implemented";

        public (string, string) AllParts(IEnumerable<string> input)
        {
            return (PartOne(input), "Not Implemented");
        }

        public static IEnumerable<IEnumerable<string>> Chunkify(IEnumerable<string> input)
        {
            var results = new List<IEnumerable<string>>();
            string chunk = "";

            foreach (string line in input)
            {
                if (line.Length > 0) { chunk += (line + " "); }
                else
                {
                    results.Add(chunk.Split(' ').SkipLast(1)); chunk = "";
                }
            }
            results.Add(chunk.Split(' ').SkipLast(1));

            return results;
        }

        static bool IsValidCredential1(IEnumerable<string> pieces)
        {
            var credentials =
                creds()
                .Select(x => pieces.FirstOrDefault(y => IsCred(x, y)));

            if (credentials.All(x => x is not null))
            { return true; }
            else { return false; }
        }

        static bool IsLongEnough(IEnumerable<string> pieces) => pieces.Count() >= 7;

        static bool IsCred(Cred cred, string input) => input[0..3] == cred.ToString();
    }
}