using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using PowerPlantCodingChallenge.Requests;
using PowerPlantCodingChallenge.Response;

namespace PowerPlantCodingChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PowerPlantController : Controller
    {

        PowerPlantManager powerPlantManager = new PowerPlantManager();

        /// <summary>
        /// Testssss
        /// </summary>
        /// <param name="apiRequest"></param>
        /// <returns></returns>
        [HttpPost("productionplan")]
        [ProducesResponseType(200, Type = typeof(PowerPlantsDeliveryApiResponse))]
        public IActionResult GetProductionPlan([FromBody]PowerPlantsDeliveryApiRequest apiRequest)
        {
            var test = apiRequest.Fuels.Wind;
            powerPlantManager.Run(apiRequest.PowerPlants, apiRequest.Fuels);

            return View();
        }
    }
}
