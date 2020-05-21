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

        ResourceBuilder _resourceBuilder = new ResourceBuilder();
        public PowerPlantBuilder()
        {
        }


        public List<PowerPlant<Fuel>> Build<T>(PowerPlantViewModel[] centrals, T fuel) where T: Fuel
        {
            if (!KnownPowerPlants.Listing.Keys.Contains(typeof(T))) throw new Exception("Unknow PowerPlant type");

            return centrals.
                Where(central => central.Type == KnownPowerPlants.Listing[typeof(T)])
                .Select(central => new PowerPlant<Fuel>
                (
                    fuel
                    , central.Name
                    , new PositiveDecimal(central.Efficiency)
                    , new PositiveDecimal(central.PMin)
                    , new PositiveDecimal(central.PMax)
                ))
                .ToList();
        }

        public List<PowerPlant<Fuel>> Build(PowerPlantViewModel[] centrals, FuelViewModel fuelViewModel)
        {
            List<PowerPlant<Fuel>> powerPlants = new List<PowerPlant<Fuel>>();
            powerPlants.AddRange( centrals
                .Where(central => central.Type == KnownPowerPlants.Listing[typeof(Wind)])
                .Select(central => new PowerPlant<Fuel>
                (
                    _resourceBuilder.BuildWindFuel(fuelViewModel.Wind)
                    , central.Name
                    , new PositiveDecimal(central.Efficiency)
                    , new PositiveDecimal(central.PMin)
                    , new PositiveDecimal(central.PMax * fuelViewModel.Wind)
                )));

            powerPlants.AddRange(centrals
            .Where(central => central.Type == KnownPowerPlants.Listing[typeof(Gas)])
            .Select(central => new PowerPlant<Fuel>
            (
                _resourceBuilder.BuildGasFuel(fuelViewModel.Gas, fuelViewModel.Wind)
                , central.Name
                , new PositiveDecimal(central.Efficiency)
                , new PositiveDecimal(central.PMin)
                , new PositiveDecimal(central.PMax)
            )));

            powerPlants.AddRange(centrals
           .Where(central => central.Type == KnownPowerPlants.Listing[typeof(Kerosine)])
           .Select(central => new PowerPlant<Fuel>
           (
               _resourceBuilder.BuildKerosineFuel(fuelViewModel.Kerosine)
               , central.Name
               , new PositiveDecimal(central.Efficiency)
               , new PositiveDecimal(central.PMin)
               , new PositiveDecimal(central.PMax)
           )));

            return powerPlants;
        }
    }
}
