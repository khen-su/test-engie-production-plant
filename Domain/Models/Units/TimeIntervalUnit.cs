using System;
namespace Domain.Models.Units
{
    public class TimeInterval
    {
        public decimal Interval { get; }
        public TimeIntervalUnit Unit { get; }
        public TimeInterval(PositiveDecimal interval, TimeIntervalUnit unit)
        {
            Interval = interval.Value;
            Unit = unit;
        }

    }
    public class TimeIntervalUnit : Unit
    {
        public static TimeIntervalUnit minute = new Minute();
        public static TimeIntervalUnit hour = new Hour();
        public static TimeIntervalUnit day = new Day();
        public static TimeIntervalUnit second = new Second();

        private TimeIntervalUnit(string unit, PositiveDecimal scale) : base(unit, scale)
        {

        }

        private class Second : TimeIntervalUnit
        {
            public Second() : base("seconds", new PositiveDecimal(1))
            {
            }
        }

        private class Minute : TimeIntervalUnit
        {
            public Minute() : base("minutes", new PositiveDecimal(60))
            {
            }
        }

        private class Hour : TimeIntervalUnit
        {
            public Hour() : base("hours", new PositiveDecimal(3600))
            {
            }
        }

        private class Day : TimeIntervalUnit
        {
            public Day() : base("day", new PositiveDecimal(43200))
            {
            }
        }
    }
}
