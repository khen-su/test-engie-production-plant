using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.PowerPlants;

namespace Domain
{
    public class MeritOrderLogic: IMeritOrderLogic
    {

        public Queue<KeyValuePair<decimal, PowerPlant<Fuel>>>Sort(Dictionary<string, PowerPlant<Fuel>> powerplants)
        {
            List<KeyValuePair<decimal, PowerPlant<Fuel>>> powerPlantsWithOutput = new List<KeyValuePair<decimal, PowerPlant<Fuel>>>();

           powerplants.Values.ToList().ForEach(powerPlant => powerPlantsWithOutput.Add(new KeyValuePair<decimal , PowerPlant<Fuel> >(CostUnit(powerPlant.Efficiency, powerPlant.Fuel.PricePerUnit.Price), powerPlant)));
            return new Queue<KeyValuePair<decimal, PowerPlant<Fuel>>>(powerPlantsWithOutput.OrderBy(output => output.Key));
        }
        private decimal CostUnit(decimal efficiency, decimal price) => price / efficiency;
    }
}