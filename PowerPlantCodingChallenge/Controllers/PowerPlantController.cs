using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerPlantCodingChallenge.Requests;

namespace PowerPlantCodingChallenge.Controllers
{
    [ApiController]
    public class PowerPlantController : Controller
    {

        private readonly IPowerPlantManager _powerPlantManager;
        private readonly ISimpleWebSocketHandler _webSocketHandler;
        private readonly ILogger<PowerPlantController> _logger;

        public PowerPlantController
            (
                IPowerPlantManager powerPlantManager
                , ISimpleWebSocketHandler webSocketHandler
                , ILogger<PowerPlantController> logger
            )
        {
            _powerPlantManager = powerPlantManager;
            _webSocketHandler = webSocketHandler;
            _logger = logger;
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
                _logger.LogInformation("A request was made to get the production plan.");
                Queue<ProductionOutput> outputs =  _powerPlantManager.Run(apiRequest.PowerPlants, apiRequest.Fuels, apiRequest.Load).Outputs;
                //Send back websocket to all
                _logger.LogInformation("Request and Response is being sent to all connected websocket user");
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
