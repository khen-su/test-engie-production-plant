using System;
using System.Collections.Generic;
using Domain.Models;
using Domain.Models.PowerPlants;

namespace Domain.Interfaces
{
    public interface IMeritOrderLogic
    {
        Queue<KeyValuePair<decimal, PowerPlant<Fuel>>> Sort(Dictionary<string, PowerPlant<Fuel>> powerplants);
    }
}
