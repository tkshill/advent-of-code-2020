#nullable enable annotations
#nullable enable warnings

using AOC;

namespace Results
{
    public enum Day
    {
        One,
        Two,
        Three
    }
    public static class Results
    {
        public static IResult Day1() => new DayOne.Result();
        public static IResult Day2() => new DayTwo.Result();
        public static IResult Day3() => new DayThree.Result();
    }
}