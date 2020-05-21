using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.ViewModels
{
    public class FuelViewModel
    {
        [JsonPropertyName("gas(euro/MWh)")]
        public decimal Gas { get; set; }
        [JsonPropertyName("kerosine(euro/MWh)")]
        public decimal Kerosine { get; set; }
        [JsonPropertyName("co2(euro/ton)")]
        public decimal Co2 { get; set; }
        [JsonPropertyName("wind(%)")]
        [Range(0,100)]
        public decimal Wind { get { return _windPercentage; } set { _windPercentage = value / 100; } }
        [JsonIgnore]
        private decimal _windPercentage { get; set; }
    }
}
