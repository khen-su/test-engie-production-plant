using System;
using System.Text.Json.Serialization;

namespace Domain.ViewModels
{
    public class PowerPlantViewModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("efficiency")]
        public decimal Efficiency { get; set; }
        [JsonPropertyName("pmin")]
        public decimal PMin { get; set; }
        [JsonPropertyName("pmax")]
        public decimal PMax { get; set; }
    }
}
