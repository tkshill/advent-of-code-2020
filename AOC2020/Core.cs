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
        public static IResult Day1() => new DayOneResult();
        public static DayTwoResult Day2() => new DayTwoResult();
    }
}