using System;
using Domain.Models;
using Domain.Models.Fuels;
using Domain.Models.Units;

namespace Domain.Builders
{
    public class ResourceBuilder
    {
        public Gas BuildGasFuel(decimal price, decimal co2)
        {
            return new Gas(new PricePerUnit(new PositiveDecimal(price), EnergyUnit.megaWatt)
                            , BuildCo2Waste(co2));
        }
        private Co2 BuildCo2Waste(decimal co2)
        {
          return new Co2(new PricePerUnit(new PositiveDecimal(co2), WeightUnit.killogram));
        }

        public Kerosine BuildKerosineFuel(decimal price)
        {
            return new Kerosine(new PricePerUnit(new PositiveDecimal(price), EnergyUnit.megaWatt));
        }
    }
}
