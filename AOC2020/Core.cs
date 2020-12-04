#nullable enable annotations
#nullable enable warnings

using AOC;

namespace Results
{
    public enum Day
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Eleven
    }
    public static class Results
    {
        public static IResult Day1() => new DayOne.Result();
        public static IResult Day2() => new DayTwo.Result();
        public static IResult Day3() => new DayThree.Result();
        public static IResult Day4() => new DayFour.Result();
        public static IResult Day5() => new DayFive.Result();
        public static IResult Day6() => new DaySix.Result();
        public static IResult Day7() => new DaySeven.Result();
        public static IResult Day8() => new DayEight.Result();
        public static IResult Day9() => new DayNine.Result();
        public static IResult Day10() => new DayTen.Result();
        public static IResult Day11() => new DayEleven.Result();
    }
}