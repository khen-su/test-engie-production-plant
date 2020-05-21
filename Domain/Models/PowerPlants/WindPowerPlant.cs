using System;
using Domain.Models.Fuels;

namespace Domain.Models.PowerPlants
{
    public class WindPowerPlant : PowerPlant<Wind>
    {
        public WindPowerPlant(Wind fuel, string name, PositiveDecimal efficiency, PositiveDecimal pmin, PositiveDecimal pmax) : base(fuel, name, efficiency, pmin, pmax)
        {
            PMax *= fuel.Intensity;
        }
    }
}
