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
    }
}
