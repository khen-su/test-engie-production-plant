using System;

namespace Domain.Models.Units
{
    public class PricePerUnit
    {
        public decimal Price { get; }
        public Unit Unit { get; }
        public PricePerUnit(PositiveDecimal price, Unit unit)
        {
            Price = price.Value;
            Unit = unit;
        }

        public static PricePerUnit operator *(PricePerUnit a, decimal b)
        {
            if (b < 0) throw new Exception("Invalid multiplier");
            return new PricePerUnit(new PositiveDecimal(a.Price * b), a.Unit);
        }

        public static PricePerUnit operator *(PricePerUnit a, PricePerUnit b)
        {
            if (a.Unit != b.Unit) throw new Exception("Unit are not of the same type");
            return new PricePerUnit(new PositiveDecimal(a.Price * b.Price), a.Unit);
        }

        public static PricePerUnit operator +(PricePerUnit a , PricePerUnit b)
        {
            if (a.Unit != b.Unit) throw new Exception("Unit are not of the same type");
            return new PricePerUnit(new PositiveDecimal(a.Price + b.Price), a.Unit);
        }

    }

    public class PricePerUnitZero: PricePerUnit
    {
        public PricePerUnitZero(): base(new PositiveDecimal(0), EnergyUnit.megaWatt)
        {
        }
        
    }
}
