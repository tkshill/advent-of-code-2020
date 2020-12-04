using System.Linq;
using Xunit;
using System.IO;
using System.Collections.Generic;
using System;

namespace AOC2020.Tests
{
    public class DayFourTests
    {
        public enum TestEnum { One, two }

        [Fact]
        public void TestChunk()
        {
            IEnumerable<string> testInput = File.ReadAllLines("./DayFourSampleInput.txt");
            var expected = 4;
            var actual = DayFour.Result.Chunkify(testInput).Count();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSplit()
        {
            IEnumerable<string> testInput = File.ReadAllLines("./DayFourSampleInput.txt");
            var pieces = DayFour.Result.Chunkify(testInput).First();
            foreach (string piece in pieces) { Console.WriteLine("piece: {0}", piece); }
            var actual = pieces.Count();
            var expected = 8;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestEnumAssumption()
        {
            Assert.True("One" == TestEnum.One.ToString());
            Assert.True("two" == TestEnum.two.ToString());
        }

    }
}
