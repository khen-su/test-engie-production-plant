using System;
using System.Collections.Generic;
using Domain.Models;
using Infrastructure;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PowerPlantCodingChallenge.Requests;

namespace PowerPlantCodingChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PowerPlantController : Controller
    {

        private readonly IPowerPlantManager _powerPlantManager;

        public PowerPlantController
            (
                IPowerPlantManager powerPlantManager
            )
        {
            _powerPlantManager = powerPlantManager;
        }

        /// <summary>
        /// Take a list of resource costs and powerplants for a specific load and send back their optimal production plan for the load
        /// </summary>
        /// <param name="apiRequest"></param>
        /// <returns></returns>
        [HttpPost("productionplan")]
        [ProducesResponseType(200, Type = typeof(Queue<ProductionOutput>))]
        public IActionResult GetProductionPlan([FromBody]PowerPlantsDeliveryApiRequest apiRequest)
        {
            SimpleWebSocketHandler simpleWebSocketHandler = new SimpleWebSocketHandler();

            try
            {
                var outputs =  _powerPlantManager.Run(apiRequest.PowerPlants, apiRequest.Fuels, apiRequest.Load).Outputs;
                simpleWebSocketHandler.SendMessage(new WebSocketResponse(apiRequest, outputs));
                return Ok(outputs);
            }
            catch (Exception ex)
            {
                simpleWebSocketHandler.SendMessage(new WebSocketResponse(apiRequest, null));
                return new BadRequestObjectResult(ex);
            }            
        }
    }
}
