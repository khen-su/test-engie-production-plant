using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Domain.Models.PowerPlants;

namespace Domain
{
    public class MeritOrderLogic
    {


        public Queue<PowerPlant<T>> Sort<T>(Dictionary<string, PowerPlant<T>> powerplants) where T : Fuel
        {
            Queue<PowerPlant<T>> finalQueue = new Queue<PowerPlant<T>>();

            foreach(var powerPlant in powerplants)
            {
                PowerPlant<T> optimalOutput = OptimalOutput<T>(powerplants.Values);
                powerplants.Remove(powerPlant.Key);
                finalQueue.Enqueue(optimalOutput);
            }

            return finalQueue;
        }

        public PowerPlant<T> OptimalOutput<T>(IEnumerable<PowerPlant<T>> powerPlants) where T: Fuel
        {

            return null;
        }

    }
}
