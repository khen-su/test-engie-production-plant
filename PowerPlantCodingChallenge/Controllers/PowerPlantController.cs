using Domain.Models;
using Domain.Models.Fuels;
using Domain.Models.Type;
using Microsoft.AspNetCore.Mvc;
using PowerPlantCodingChallenge.Requests;
using PowerPlantCodingChallenge.Response;

namespace PowerPlantCodingChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PowerPlantController : Controller
    {

        /// <summary>
        /// Testssss
        /// </summary>
        /// <param name="apiRequest"></param>
        /// <returns></returns>
        [HttpPost("productionplan")]
        [ProducesResponseType(200, Type = typeof(PowerPlantsDeliveryApiResponse))]
        public IActionResult GetProductionPlan([FromBody]PowerPlantsDeliveryApiRequest apiRequest)
        {
            //EnergyBilling energyBilling = new EnergyBilling(new Energy(new PositiveDecimal(250000), EnergyUnit.watt), new TimeInterval(new PositiveDecimal(2.5m), TimeIntervalUnit.hour));

            //EnergyBilling newEnergyBilling = energyBilling.Convert(EnergyUnit.megaWatt, TimeIntervalUnit.day);

            var co2 = new Co2(new PricePerUnit(new PositiveDecimal(10), EnergyUnit.megaWatt));

            return View();
        }
    }
}
