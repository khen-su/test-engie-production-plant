using System;
using Domain.Models.Units;

namespace Domain.Models.Fuels
{
    public class RatioToWaste
    {
        public PricePerUnit PricePerUnit { get; }
        public RatioToWaste(PricePerUnit ratio, Co2 waste)
        {
            PricePerUnit = ratio * waste.PricePerUnit.Price ;
        }
    }


    public class RatioToWasteZero: RatioToWaste
    {
        public RatioToWasteZero(): base(new PricePerUnit(new PositiveDecimal(0), EnergyUnit.megaWatt), new Co2(new PricePerUnit(new PositiveDecimal(1), EnergyUnit.megaWatt)))
        {
        }
    }
}
