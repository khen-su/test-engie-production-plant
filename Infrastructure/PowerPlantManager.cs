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

        public ProductionPipeline Run(PowerPlantViewModel[] powerPlantViewModels, FuelViewModel fuelViewModel)
        {
            ProductionPipeline productionPipeline = new ProductionPipeline();

            List<PowerPlant<Fuel>> powerPlants = powerPlantBuilder.Build(powerPlantViewModels, fuelViewModel);

            Queue<PowerPlant<Fuel>> queue = new Queue<PowerPlant<Fuel>>();

            Queue<PowerPlant<Fuel>> sortedWindPowerPlant = meritOrderLogic.Sort(powerPlants.ToDictionary(powerplant => powerplant.Name, powerplant => powerplant));

            return null;
        }



    }
}
