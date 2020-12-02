using DayOne;
using DayTwo;
using AOC;

namespace Results
{
    public enum Day
    {
        One,
        Two
    }
    public static class Results
    {
        public static IResult Day1() => new DayOne.Result();
        public static IResult Day2() => new DayTwo.Result();
    }
}