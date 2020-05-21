using Domain.Models.Units;

namespace Domain.Models.Fuels
{
    public class Gas : Fuel
    {
        public Gas(PricePerUnit pricePerUnit, Co2 waste) : base(new ValidName("gas"), pricePerUnit, new RatioToWaste(new PricePerUnit(new PositiveDecimal(0.3m), EnergyUnit.megaWatt), waste))
        {
        }
    }
}
