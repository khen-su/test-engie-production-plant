using System.Collections.Generic;
using System.Linq;
using Domain.Builders.Interface;
using Domain.Models;
using Domain.Models.Constants;
using Domain.Models.Fuels;
using Domain.Models.PowerPlants;
using Domain.ViewModels;

namespace Domain.Builders
{
    public class PowerPlantBuilder: IPowerPlantBuilder
    {

        private readonly IResourceBuilder _resourceBuilder;
        public PowerPlantBuilder
            (
                IResourceBuilder resourceBuilder
            )
        {
            _resourceBuilder = resourceBuilder;
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
