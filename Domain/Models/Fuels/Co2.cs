using System;
using Domain.Models.Units;

namespace Domain.Models.Fuels
{
    public class Co2
    {
        public PricePerUnit PricePerUnit { get; }
        public Co2(PricePerUnit pricePerUnit)
        {
            PricePerUnit = pricePerUnit;
        }
    }
}
