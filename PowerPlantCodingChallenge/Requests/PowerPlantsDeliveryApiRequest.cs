using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.ViewModels;

namespace PowerPlantCodingChallenge.Requests
{
    public class PowerPlantsDeliveryApiRequest
    {
        [JsonPropertyName("load")]
        public decimal Load { get; set; }
        [Required]
        [JsonPropertyName("fuels")]
        public FuelViewModel Fuels { get; set; }
        [Required]
        [JsonPropertyName("powerplants")]
        public PowerPlantViewModel[] PowerPlants { get; set; }
    }
}
