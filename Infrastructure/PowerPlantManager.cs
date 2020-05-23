using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Builders.Interface;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.PowerPlants;
using Domain.ViewModels;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public class PowerPlantManager : IPowerPlantManager
    {
        private readonly IPowerPlantBuilder _powerPlantBuilder;
        private readonly IMeritOrderLogic _meritOrderLogic;
        private readonly ILogger<PowerPlantManager> _logger;

        public PowerPlantManager
            (
                IPowerPlantBuilder powerPlantBuilder,
                IMeritOrderLogic meritOrderLogic,
                ILogger<PowerPlantManager> logger
            )
        {
            _logger = logger ?? throw new NullReferenceException($"{nameof(logger)} can't be null");

            _powerPlantBuilder = powerPlantBuilder ?? throw new NullReferenceException($"{nameof(powerPlantBuilder)} can't be null");
            _meritOrderLogic = meritOrderLogic ?? throw new NullReferenceException($"{nameof(meritOrderLogic)} can't be null");
        }

        public ProductionPipeline Run(PowerPlantViewModel[] powerPlantViewModels, FuelViewModel fuelViewModel, decimal load)
        {
            try
            {
                _logger.LogDebug("Building powerplant list");
                List<PowerPlant<Fuel>> powerPlants = _powerPlantBuilder.Build(powerPlantViewModels, fuelViewModel);

                _logger.LogDebug("Merit-Order sorting algorithm");
                Queue<KeyValuePair<decimal, PowerPlant<Fuel>>> sortedPowerPlant = _meritOrderLogic.Sort(powerPlants.ToDictionary(powerplant => powerplant.Name, powerplant => powerplant));

                _logger.LogDebug("Deciding production rate for each  powerplan...");
                return new ProductionPipelineLogic(new PositiveDecimal(load))
                            .Run(sortedPowerPlant);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

    }
}
