using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
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
        private readonly ISimpleWebSocketHandler _webSocketHandler;

        public PowerPlantController
            (
                IPowerPlantManager powerPlantManager
                , ISimpleWebSocketHandler webSocketHandler
            )
        {
            _powerPlantManager = powerPlantManager;
            _webSocketHandler = webSocketHandler;
        }

        /// <summary>
        /// Take a list of resource costs and powerplants for a specific load and send back their optimal production plan for the load
        /// </summary>
        /// <param name="apiRequest"></param>
        /// <returns></returns>
        [HttpPost("productionplan")]
        [ProducesResponseType(200, Type = typeof(Queue<ProductionOutput>))]
        public async Task<IActionResult> GetProductionPlan([FromBody]PowerPlantsDeliveryApiRequest apiRequest)
        {
            try
            {
                Queue<ProductionOutput> outputs =  _powerPlantManager.Run(apiRequest.PowerPlants, apiRequest.Fuels, apiRequest.Load).Outputs;
                await _webSocketHandler.SendMessage(new WebSocketResponse(apiRequest, outputs).Serialize());
                return Ok(outputs);
            }
            catch (Exception ex)
            {
                await _webSocketHandler.SendMessage(new WebSocketResponse(apiRequest, ex.ToString()).Serialize());
                return new BadRequestObjectResult(ex);
            }            
        }
    }
}
