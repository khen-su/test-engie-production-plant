using System;
using System.Collections.Generic;
using Domain.Models.Fuels;

namespace Domain.Models.Constants
{
    public class KnownPowerPlants
    {
        public static Dictionary<Type, string> Listing = new Dictionary<Type, string>() { { typeof(Gas) ,"gasfired" }, { typeof(Kerosine), "turbojet" },{typeof(Wind), "windturbine" } };
    }
}
