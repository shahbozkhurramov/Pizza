using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizza.Mapper;
using pizza.Model;
using pizza.Services;

namespace pizza.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController: ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;
        private readonly IStorageService _pizzaStorage;

        public PizzaController(ILogger<PizzaController> logger, IStorageService pizzaStorage)
        {
            _logger = logger;
            _pizzaStorage = pizzaStorage;
        }

        [HttpPost]
        [Consumes(System.Net.Mime.MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreatePizza([FromBody]NewPizza newPizza)
        {
            var pizzaEntity = newPizza.ToPizzaEntity();
            var insertResult = await _pizzaStorage.InsertPizzaAsync(pizzaEntity);

            if(!insertResult.IsSuccess)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = insertResult.exception.Message });
            }
            return CreatedAtAction("CreatePizza", pizzaEntity);

        }

        [HttpGet]
        public async Task<IActionResult> QueryPizzas([FromQuery]PizzaQuery query)
        {
            var pizzas = await _pizzaStorage.GetPizzaAsync(id: query.Id);

            if(pizzas.Any())
            {
                return Ok(pizzas);
            }

            return NotFound("No tasks exist!");
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePizza([FromRoute]Guid id)
        {
            try
            {
                var deletedResult = await _pizzaStorage.DeletePizzaAsync(id);
                if(deletedResult.IsSuccess)
                {
                    return Ok();
                }
                return BadRequest(deletedResult.exception.Message);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePizzaAsync([FromRoute]Guid id, [FromBody]UpdatedPizza updatedPizza)
        {
            var entity = updatedPizza.ToPizzaEntity();
            var updateResult = await _pizzaStorage.UpdatePizzaAsync(id, entity);

            if(updateResult.IsSuccess)
            {
                return Ok();
            }
            return BadRequest(updateResult.exception.Message);
        }
    }
}