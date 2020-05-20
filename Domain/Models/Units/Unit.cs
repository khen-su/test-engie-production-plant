using System;
namespace Domain.Models.Units
{
    public class Unit
    {
        public string BaseUnit { get; }
        public decimal Scale { get; }
        public Unit(string baseUnit, PositiveDecimal scale)
        {
            BaseUnit = baseUnit;
            Scale = scale.Value;
        }
    }
}
