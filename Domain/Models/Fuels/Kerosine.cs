using Domain.Models.Units;

namespace Domain.Models.Fuels
{
    public class Kerosine : Fuel
    {
        public Kerosine(PricePerUnit pricePerUnit) : base(new ValidName("kerosine"), pricePerUnit)
        {
        }
    }
}
