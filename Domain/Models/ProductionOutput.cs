using System;
using System.Text.Json.Serialization;
using Domain.Models.Fuels;

namespace Domain.Models
{
    public class ProductionOutput
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("p")]
        public decimal Output { get; set; }

        public ProductionOutput(ValidName name, PositiveDecimal output)
        {
            Name = name.Name;
            Output = output.Value;
        }
    }
}
