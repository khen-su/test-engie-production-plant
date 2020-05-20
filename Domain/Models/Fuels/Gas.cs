using Domain.Models.Units;

namespace Domain.Models.Fuels
{
    public class Gas : Fuel
    {
        public Co2 Waste { get; set; }
        public Gas(PricePerUnit pricePerUnit, Co2 waste) : base(new ValidName("gas"), pricePerUnit)
        {
            Waste = waste;
        }
    }
}
