using System;
using Domain.Models;
using Domain.ViewModels;

namespace Infrastructure.Interfaces
{
    public interface IPowerPlantManager
    {
        ProductionPipeline Run(PowerPlantViewModel[] powerPlantViewModels, FuelViewModel fuelViewModel, decimal load);
    }
}
