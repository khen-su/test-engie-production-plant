using System;
using Domain.Models.Fuels;

namespace Domain.Models.PowerPlants
{
    public class GasPowerPlant : PowerPlant
    {
        public GasPowerPlant(Gas fuel, string Name, decimal efficiency, decimal pmin, decimal pmax) : base(fuel, Name, efficiency, pmin, pmax)
        {
        }
    }
}
