using System.Collections.Generic;
using Domain.Models;
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
        /// Take a list of resource costs and powerplants for a specific load and send back their optimal production plan for the load
        /// </summary>
        /// <param name="apiRequest"></param>
        /// <returns></returns>
        [HttpPost("productionplan")]
        [ProducesResponseType(200, Type = typeof(Queue<ProductionOutput>))]
        public IActionResult GetProductionPlan([FromBody]PowerPlantsDeliveryApiRequest apiRequest)
        {
            return Ok(powerPlantManager.Run(apiRequest.PowerPlants, apiRequest.Fuels, apiRequest.Load).Outputs);
        }
    }
}
