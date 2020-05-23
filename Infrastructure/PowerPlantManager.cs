using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Builders;
using Domain.Models;
using Domain.Models.Fuels;
using Domain.Models.PowerPlants;
using Domain.ViewModels;

namespace Infrastructure
{
    public class PowerPlantManager
    {

        public ResourceBuilder resourceBuilder = new ResourceBuilder();
        public PowerPlantBuilder powerPlantBuilder = new PowerPlantBuilder();

        MeritOrderLogic meritOrderLogic = new MeritOrderLogic();

        public ProductionPipeline Run(PowerPlantViewModel[] powerPlantViewModels, FuelViewModel fuelViewModel, decimal load)
        {
            List<PowerPlant<Fuel>> powerPlants = powerPlantBuilder.Build(powerPlantViewModels, fuelViewModel);

            Queue<KeyValuePair<decimal, PowerPlant<Fuel>>> sortedPowerPlant = meritOrderLogic.Sort(powerPlants.ToDictionary(powerplant => powerplant.Name, powerplant => powerplant));

            return new ProductionPipelineLogic(new PositiveDecimal(load))
                        .Run(sortedPowerPlant);
        }



    }
}
