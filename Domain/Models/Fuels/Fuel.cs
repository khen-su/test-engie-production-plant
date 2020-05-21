using Domain.Models.Fuels;
using Domain.Models.Units;

namespace Domain.Models
{
    public abstract class Fuel
    {
        #region internal fields
        public PricePerUnit PricePerUnit { get; }
        public string Name { get; }
        #endregion

        public Fuel(ValidName resource, PricePerUnit pricePerUnit, RatioToWaste waste)
        {
            PricePerUnit = PricePerUnitWithWaste(pricePerUnit, waste.PricePerUnit);
            Name = resource.Name;
        }

        public PricePerUnit PricePerUnitWithWaste(PricePerUnit pricePerUnit, PricePerUnit wastePerUnit)
        {
            return pricePerUnit + wastePerUnit;
        }

    }
}
