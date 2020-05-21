using System;
using Domain.Models.Constants;

namespace Domain.Models.PowerPlants
{
    public class PowerPlant<T> where T: Fuel
    {
        public string Name { get;}
        public T Fuel { get; set; }
        public decimal Efficiency { get;}
        public decimal PMin { get;  }
        public decimal PMax { get; protected set; }


        public PowerPlant(T fuel, string name, PositiveDecimal efficiency, PositiveDecimal pmin, PositiveDecimal pmax)
        {
            Fuel = fuel;
            Name = name;
            Efficiency = efficiency.Value;
            PMin = pmin.Value;
            PMax = pmax.Value;
        }

    }
}

