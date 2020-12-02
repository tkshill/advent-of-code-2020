using System.Collections.Generic;
using System.Linq;
using AOC;

namespace DayOne
{
    public class DayOneResult : IResult
    {
        public string filepath() => "./DayOne/input.txt";

        public string PartOne(IEnumerable<string> input)
        {
            IEnumerable<int> inputNum = input.Select(int.Parse);
            IEnumerable<int> pair = TryFindPair(inputNum);

            return FindProduct(pair).ToString();
        }

        public string PartTwo(IEnumerable<string> input)
        {
            IEnumerable<int> inputNum = input.Select(int.Parse);
            IEnumerable<int> pair = TryFindTriplet(inputNum);

            return FindProduct(pair).ToString();
        }

        public (string, string) AllParts(IEnumerable<string> input) =>
            (PartOne(input), PartTwo(input));

        static IEnumerable<int> TryFindPair(IEnumerable<int> input)
        {
            foreach (var (item, index) in input.Select((value, i) => (value, i)))
            {
                IEnumerable<int> remaining = input.Skip(index + 1);
                foreach (int item2 in remaining)
                {
                    int[] values = { item, item2 };
                    if (AreIntsEqualTo(2020, values))
                    {
                        return values;
                    }
                }
            }
            return Enumerable.Empty<int>();
        }

        static IEnumerable<int> TryFindTriplet(IEnumerable<int> input)
        {
            foreach (var (item, index) in input.Select((value, i) => (value, i)))
            {
                IEnumerable<int> afterValueOne = input.Skip(index + 1);

                foreach (var (item2, index2) in afterValueOne.Select((value, i) => (value, i)))
                {
                    IEnumerable<int> afterValueTwo = input.Skip(index2 + 1);

                    foreach (int item3 in afterValueTwo)
                    {
                        int[] values = { item, item2, item3 };
                        if (AreIntsEqualTo(2020, values))
                        {
                            return values;
                        }
                    }
                }
            }
            return Enumerable.Empty<int>();
        }

        static bool AreIntsEqualTo(int check, IEnumerable<int> values) =>
            (Enumerable.Sum(values) == check);

        static int FindProduct(IEnumerable<int> nums) =>
            nums.Aggregate(1, (prod, next) => prod * next);
    }
}