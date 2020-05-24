using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Domain.Models.Fuels;
using Domain.Models.PowerPlants;
using Domain.Models.Units;

namespace Domain
{
    public class ProductionPipelineLogic
    {
        public decimal Load { get; }

        public ProductionPipelineLogic(PositiveDecimal load)
        {
            Load = load.Value;
        }

        public ProductionPipeline Run(Queue<KeyValuePair<decimal, PowerPlant<Fuel>>> sortedPowerPlants)
        {
            decimal leftload = Load;
            Queue<ProductionOutput> productionOutputs = new Queue<ProductionOutput>();
            PowerPlant<Fuel>[] powerPlants = sortedPowerPlants
                                                .Select(x => x.Value)
                                                .ToArray();
            for (int index = 0; index < powerPlants.Count(); index++)
            {
                decimal production = GetProduction(powerPlants[index], new ArraySegment<PowerPlant<Fuel>>(powerPlants, index, powerPlants.Count() - index - 1), leftload);
                leftload -= production;
                productionOutputs.Enqueue(new ProductionOutput(new ValidName(powerPlants[index].Name), new PositiveDecimal(production)));
            }
            return new ProductionPipeline(productionOutputs);
        }

        private decimal GetProduction(PowerPlant<Fuel> current, IEnumerable<PowerPlant<Fuel>> nexts,  decimal leftLoad)
        {
            //Select next most relevant powerPlant to watch for
            PowerPlant<Fuel> next = GetLastPertinentPowerPlant(nexts, leftLoad - current.PMax);

            //If the maximum production is higher than the load to cover...
            if (current.PMax >= leftLoad)
            {
                //and if the min prod of the current power plant does not go beyond the load...
                if (current.PMin > leftLoad ) return 0;
                //then the central produce the load which is left to cover
                return leftLoad;
            }
            //Else we need to make sure this current powerplant is better than the next one if we were forced to pick between one or the other
            else
            {

                // The optimal output is the max prod for the current powerplant while having enough prod to trigger next powerplant
                decimal optimalOutput =  Math.Min(leftLoad - next.PMin, current.PMax);
                // If the min prod of next powerplant is higher than what's left of the load, we intend to skip it, so we send back max prod for the current plant
                if (optimalOutput < 0) return current.PMax;
                //If the optimal output is lower than the minimum prod for the current powerplant... 
                if (optimalOutput < current.PMin)
                {
                    //either we return the max prod for that current powerplant because we intend to skip the next one...
                    if (current.PMax > next.PMax ) return current.PMax;
                    //or skip this powerplant
                    return 0;
                }
                //if ((leftLoad - current.PMin) < next.PMin) return 0;
                return optimalOutput;
            }
        }

        // "Last pertinent" means the last powerplant of the sub-array whose max production sum is equal or just beyond the load to cover 
        private PowerPlant<Fuel> GetLastPertinentPowerPlant(IEnumerable<PowerPlant<Fuel>> powerPlants, decimal load)
        {
            decimal energySum = 0;

            foreach(var powerPlant in powerPlants)
            {
                energySum += powerPlant.PMax;
                if (energySum >= load) return powerPlant;
            }

            return new PowerPlant<Fuel>(new Kerosine(new PricePerUnitZero()),"Default", new PositiveDecimal(0), new PositiveDecimal(0), new PositiveDecimal(0));

        }
    }
}
