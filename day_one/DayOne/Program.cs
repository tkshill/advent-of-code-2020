using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DayOne
{
    enum Part
    {
        One,
        Two
    }
    class Program
    {
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

        static IEnumerable<int> FilePathToList(string filepath) =>
            File.ReadAllLines(filepath)
                .Select(int.Parse);

        static bool AreIntsEqualTo(int check, IEnumerable<int> values) =>
            (Enumerable.Sum(values) == check);

        static IEnumerable<int> TryFindResults(Part part, IEnumerable<int> input) =>
            part switch
            {
                Part.One => TryFindPair(input),
                Part.Two => TryFindTriplet(input),
                _ => throw new ArgumentOutOfRangeException()
            };

        static void Main(string[] args)
        {
            const String inputFilePath = "./input.txt";

            IEnumerable<int> inputList = FilePathToList(inputFilePath);

            IEnumerable<int> result = TryFindResults(Part.Two, inputList);

            int answer = result.Aggregate(1, (prod, next) => prod * next);

            Console.WriteLine(answer);
        }
    }
}
