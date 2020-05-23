using System;
using System.Collections.Generic;
using Domain.Models;
using Domain.Models.PowerPlants;
using Domain.ViewModels;

namespace Domain.Builders.Interface
{
    public interface IPowerPlantBuilder
    {
        List<PowerPlant<Fuel>> Build(PowerPlantViewModel[] centrals, FuelViewModel fuelViewModel);
    }
}
