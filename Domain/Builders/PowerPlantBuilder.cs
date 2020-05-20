using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Domain.Models.Constants;
using Domain.Models.Fuels;
using Domain.Models.PowerPlants;
using Domain.Models.Units;
using Domain.ViewModels;

namespace Domain.Builders
{
    public class PowerPlantBuilder
    {
        public PowerPlantBuilder()
        {
        }


        public List<PowerPlant<T>> Build<T>(List<PowerPlantViewModel> centrals, T fuel) where T: Fuel
        {
            if (!KnownPowerPlants.Listing.Keys.Contains(typeof(T))) throw new Exception("Unknow PowerPlant type");

            return centrals.
                Where(central => central.Type == KnownPowerPlants.Listing[typeof(T)])
                .Select(central => new PowerPlant<T>
                (
                    fuel
                    , central.Name
                    , new PositiveDecimal(central.Efficiency)
                    , new PositiveDecimal(central.PMin)
                    , new PositiveDecimal(central.PMax)
                ))
                .ToList();
        }

     




    }
}
