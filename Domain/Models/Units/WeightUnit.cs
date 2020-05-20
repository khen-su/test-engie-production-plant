using System;
namespace Domain.Models.Units
{
    public class WeightUnit : Unit
    {
        public static WeightUnit killogram = new Killogram();
        public static WeightUnit ton = new Ton();

        private WeightUnit(string unit, PositiveDecimal scale) : base(unit, scale)
        {

        }

        private class Killogram : WeightUnit
        {

            public Killogram() : base("killogram", new PositiveDecimal(1000))
            {

            }

        }

        private class Ton : WeightUnit
        {

            public Ton() : base("ton", new PositiveDecimal(1000000))
            {

            }

        }
    }
}
