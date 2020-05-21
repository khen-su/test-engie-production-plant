using System;
using Domain.Models.Fuels;

namespace Domain.Models
{
    public class ProductionOutput
    {
        public string Name { get; set; }
        public decimal Output { get; set; }

        public ProductionOutput(ValidName name, PositiveDecimal output)
        {
            Name = name.Name;
            Output = output.Value;
        }
    }
}
